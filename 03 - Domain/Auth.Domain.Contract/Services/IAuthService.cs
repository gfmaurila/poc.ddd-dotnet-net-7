using Auth.App.Dto.Auth;

namespace Auth.Domain.Contract.Services;
public interface IAuthService
{
    Task<TokenDto> Auth(LoginDto dto);
}
