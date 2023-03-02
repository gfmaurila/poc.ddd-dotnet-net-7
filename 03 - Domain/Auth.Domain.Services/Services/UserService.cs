using Auth.App.Dto.Auth;
using Auth.App.Dto.Menssage;
using Auth.App.Enums;
using Auth.App.Response;
using Auth.Domain.Contract.MessageBus;
using Auth.Domain.Contract.Repositorys;
using Auth.Domain.Contract.Services;
using Auth.Domain.Entities.Identity;
using Auth.Domain.Entities.Users;
using Auth.Infrastruture.CrossCutting.Exceptions;
using Auth.Infrastruture.CrossCutting.Handle;
using Auth.Infrastruture.CrossCutting.Helper;
using Auth.Infrastruture.CrossCutting.Service;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace Auth.Domain.Services.Services;

public class UserService : BaseService, IUserService
{
    private readonly IMapper _mapper;
    private readonly UserManager<UserModel> _userManager;
    private readonly IUserCodeResetRepository _repoUserCodeReset;
    private readonly ILogger<UserService> _logger;
    private readonly IConfiguration _configuration;
    private readonly IMessageBusService _messageBusService;

    public UserService(INotificationHandle notification,
                       IConfiguration configuration,
                       IMapper mapper, IUserRoleRepository repo,
                       ILogger<UserService> logger,
                       IMessageBusService messageBusService,
                       IUserCodeResetRepository repoUserCodeReset,
                       UserManager<UserModel> userManager) : base(notification)
    {
        _mapper = mapper;
        _logger = logger;
        _messageBusService = messageBusService;
        _repoUserCodeReset = repoUserCodeReset;
        _userManager = userManager;
        _configuration = configuration;
    }

    #region Command
    public async Task<ResponseDefault> GenerateCodeReset(GenerateCodeResetDto dto)
    {
        var list = getUser(dto.Login);

        if (list.Count != 1)
            throw new Exceptions($"Usuário incorreto");

        var user = list.First();
        await CreateUserCodeReset(user, PasswordHelper.GetSha256Hash(user.Id.ToString()));
        await Publish(dto, user);

        return new ResponseDefault
        {
            Message = "Dados enviados com sucesso",
            Success = true,
            Data = null
        };
    }

    public Task<RegisterNewPasswordDto> RegisterNewPassword(RegisterNewPasswordDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<UserCodeReset> CreateUserCodeReset(UserModel entity, string code)
    {
        var exists = await _repoUserCodeReset.GetByCodeStatus(code);
        if (exists != null)
            return null;

        return await _repoUserCodeReset.Create(new UserCodeReset()
        {
            Code = code,
            Email = entity.Email,
            UserId = entity.Id,
            UserName = entity.UserName,
            Modified = DateTime.Now,
            Status = true
        });
    }
    #endregion Command

    #region Query
    public List<UserModel> getUser(string login)
        => _userManager.Users.Where(w => w.UserName.ToLower().Trim() == login.ToLower().Trim()).ToList();

    public async Task<ValidateCodeResetDto> ValidateCodeReset(string code)
    {
        var exists = await _repoUserCodeReset.GetByCodeStatus(code);
        if (exists == null)
            throw new Exceptions($"Usuário não encontrado");

        return _mapper.Map<ValidateCodeResetDto>(exists);
    }
    #endregion Query

    #region Private
    private async Task Publish(GenerateCodeResetDto dto, UserModel user)
    {
        if (dto.Type == EGenerateCodeReset.WhatsApp)
        {
            var infoTwilio = new TwilioDto();
            infoTwilio.To = user.Email;
            infoTwilio.Body = $"Link de validação: {TinyURLHelper.Urls(_configuration["AuthApi:URL"] + "/validatecodereset/" + PasswordHelper.GetSha256Hash(user.Id.ToString()))}";
            var infoTwilioJson = JsonSerializer.Serialize(infoTwilio);
            var infoTwilioBytes = Encoding.UTF8.GetBytes(infoTwilioJson);
            _messageBusService.Publish("WhatsApp_Generate_Code_Reset", infoTwilioBytes);
        }

        if (dto.Type == EGenerateCodeReset.Email)
        {
            var infoSendGrid = new SendGridDto();
            infoSendGrid.To = user.Email;
            infoSendGrid.Name = user.UserName;
            infoSendGrid.Subject = "Reset de senha";
            infoSendGrid.HtmlContent = EmailHelper.CreateEmailBody(infoSendGrid.Name, TinyURLHelper.Urls(_configuration["AuthApi:URL"] + "/validatecodereset/" + PasswordHelper.GetSha256Hash(user.Id.ToString())));
            infoSendGrid.PlainTextContent = EmailHelper.CreateEmailBody(infoSendGrid.Name, TinyURLHelper.Urls(_configuration["AuthApi:URL"] + "/validatecodereset/" + PasswordHelper.GetSha256Hash(user.Id.ToString())));

            var infoSendGridJson = JsonSerializer.Serialize(infoSendGrid);
            var infoSendGridBytes = Encoding.UTF8.GetBytes(infoSendGridJson);
            _messageBusService.Publish("Email_Generate_Code_Reset", infoSendGridBytes);
        }
    }
    #endregion Private
}
