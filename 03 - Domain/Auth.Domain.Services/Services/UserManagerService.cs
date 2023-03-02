using Auth.App.Dto.User;
using Auth.Domain.Contract.Services;
using Auth.Domain.Entities.Identity;
using Auth.Infrastruture.CrossCutting.Exceptions;
using Auth.Infrastruture.CrossCutting.Handle;
using Auth.Infrastruture.CrossCutting.Service;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Auth.Domain.Services.Services;

public class UserManagerService : BaseService, IUserManagerService
{
    private readonly IMapper _mapper;
    private readonly ILogger<UserManagerService> _logger;

    private readonly UserManager<UserModel> _userManager;

    public UserManagerService(INotificationHandle notification, IMapper mapper, UserManager<UserModel> userManager, ILogger<UserManagerService> logger) : base(notification)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    #region Cammand  
    public async Task<UserListDto> Create(UserCreateDto dto)
    {
        var user = _mapper.Map<UserModel>(dto);

        // crar uma função de confirmação de e-mail 
        // Hj vai ficar default confirmado
        user.EmailConfirmed = true;
        user.PhoneNumberConfirmed = true;
        user.Modified = DateTime.Now;

        // valida se usuario ja existe na base 
        var exists = _userManager.Users.Where(f => f.Email == dto.Email).FirstOrDefault();

        if (exists != null)
            throw new Exceptions($"Já existe um usuário cadastrado com o email: {dto.Email} informado.");

        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                Notify(error.Description);
            }

            return null;
        }

        return _mapper.Map<UserListDto>(await _userManager.FindByNameAsync(user.UserName));
    }

    public async Task<UserListDto> Update(UserUpdateDto dto)
    {
        // valida se usuario ja existe na base 
        var user = await _userManager.FindByIdAsync(dto.Id.ToString());

        if (user == null)
            throw new Exceptions($"Não existe nenhum usuário com o id: {dto.Id} informado!");

        user.Email = dto.Email;
        user.NormalizedEmail = dto.Email;
        user.PhoneNumber = dto.PhoneNumber;

        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                Notify(error.Description);
            }
            return null;
        }
        return _mapper.Map<UserListDto>(await _userManager.FindByIdAsync(dto.Id.ToString()));
    }

    public async Task<bool> UpdatePassword(UserUpdatePasswordDto dto)
    {
        var user = _userManager.Users
                               .Where(w => w.Id == dto.Id)
                               .FirstOrDefault();

        if (user != null)
        {
            var update = await _userManager.UpdateAsync(user);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, dto.NewPassword);
            if (!result.Succeeded)
            {
                throw new Exceptions($"Não foi possível alterar senha");
            }
            return true;
        }

        throw new Exceptions($"Não existe nenhum usuário com o ID: {dto.Id} informado!");
    }

    public async Task Remove(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            throw new Exceptions($"Não existe nenhum usuário com o id: {id} informado!");

        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                Notify(error.Description);
            }
        }
    }
    #endregion Cammand    

    #region Query
    public async Task<UserListDto> Get(string id)
        => _mapper.Map<UserListDto>(await _userManager.FindByIdAsync(id));

    public async Task<List<UserListDto>> Get()
    {
        throw new NotImplementedException();
    }
    #endregion Query

}
