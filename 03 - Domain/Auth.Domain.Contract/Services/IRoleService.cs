using Auth.App.Dto.Role;

namespace Auth.Domain.Contract.Services;
public interface IRoleService
{
    Task<RolesDto> Create(RolesDto dto);
    Task<RolesDto> Update(RolesDto dto);
    Task<bool> Remove(int id);
    Task<RolesDto> Get(int id);
    Task<List<RolesDto>> Get();
}
