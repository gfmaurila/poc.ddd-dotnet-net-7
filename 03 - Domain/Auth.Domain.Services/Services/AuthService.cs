using Auth.App.Dto.Auth;
using Auth.App.Dto.User;
using Auth.Domain.Contract.Services;
using Auth.Domain.Entities.Identity;
using Auth.Infrastruture.CrossCutting.Exceptions;
using Auth.Infrastruture.CrossCutting.Handle;
using Auth.Infrastruture.CrossCutting.Service;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Auth.Domain.Services.Services;

public class AuthService : BaseService, IAuthService
{
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly ITokenGeneratorService _tokenGenerator;
    private readonly ILogger<AuthService> _logger;

    private readonly IUserRoleService _userRoleService;
    private readonly UserManager<UserModel> _userManager;
    private readonly SignInManager<UserModel> _signInManager;
    private readonly RoleManager<RoleModel> _roleManager;

    public AuthService(IConfiguration configuration,
                       INotificationHandle notification,
                       IMapper mapper,
                       ITokenGeneratorService tokenGenerator,
                       ILogger<AuthService> logger,
                       UserManager<UserModel> userManager,
                       SignInManager<UserModel> signInManager,
                       IUserRoleService userRoleService) : base(notification)
    {
        _configuration = configuration;
        _tokenGenerator = tokenGenerator;
        _userRoleService = userRoleService;
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
    }

    #region AuthAPI
    public async Task<TokenDto> Auth(LoginDto dto)
    {
        var list = _userManager.Users.Where(w => w.UserName.ToLower().Trim() == dto.Login.ToLower().Trim()).ToList();

        if (list.Count != 1)
            throw new Exceptions($"Usuário ou Senha incorretos");

        var user = list.First();

        if (!user.Status)
            throw new Exceptions($"Usuario esta desativado no sistema. Sem permissão de acesso.");

        var result = await _signInManager.PasswordSignInAsync(user.UserName, dto.Password, false, true);

        if (result.Succeeded)
        {
            var roles = await _userRoleService.GetByIdJwt(user.Id);

            if (roles.Count == 0)
                throw new Exceptions($"Usuario esta desativado no sistema. Sem permissão de acesso.");

            var maperUser = _mapper.Map<UserListDto>(user);
            return new TokenDto
            {
                Token = _tokenGenerator.GenerateToken(maperUser, roles),
                TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
            };
        }

        throw new Exceptions($"Usuário ou Senha incorretos");
    }
    #endregion
}
