using Auth.App.Dto.User;

namespace Auth.Domain.Contract.Services;
public interface IUserManagerService
{
    Task<UserListDto> Create(UserCreateDto dto);
    Task<UserListDto> Update(UserUpdateDto dto);
    Task<bool> UpdatePassword(UserUpdatePasswordDto dto);
    Task Remove(string id);
    Task<UserListDto> Get(string id);
    Task<List<UserListDto>> Get();
}
