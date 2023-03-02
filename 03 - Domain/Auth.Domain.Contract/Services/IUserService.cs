using Auth.App.Dto.Auth;
using Auth.App.Dto.User;
using Auth.App.Response;
using Auth.Domain.Entities.Identity;
using Auth.Domain.Entities.Users;

namespace Auth.Domain.Contract.Services;
public interface IUserService
{
    Task<UserCodeReset> CreateUserCodeReset(UserModel entity, string code);
    Task<ResponseDefault> GenerateCodeReset(GenerateCodeResetDto dto);
    Task<ValidateCodeResetDto> ValidateCodeReset(string code);
    Task<RegisterNewPasswordDto> RegisterNewPassword(RegisterNewPasswordDto dto);
    List<UserModel> getUser(string login);
}
