using Auth.App.Dto.UserRole;

namespace Auth.Domain.Contract.Services;
public interface IUserRoleService
{
    Task<CreateUserRoleDto> Create(CreateUserRoleDto dto);
    Task<List<UserRoleDto>> Get(UserRoleDto dto);
    Task<List<string>> GetByIdJwt(int userId);
    Task<bool> Remove(int id);
    Task<bool> RemoveAll(UserRoleDto dto);
}
