using Auth.Domain.Entities.Users;

namespace Auth.Domain.Contract.Repositorys;

public interface IRoleRepository : IBaseRepository<Role>
{
    Task<Role> GetByName(string name);
    Task<List<Role>> SearchByName(string name);
    Task<Role> GetByNameById(Role entity);
}

