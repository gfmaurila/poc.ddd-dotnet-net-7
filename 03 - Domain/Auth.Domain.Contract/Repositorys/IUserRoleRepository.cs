using Auth.Domain.Entities.Users;

namespace Auth.Domain.Contract.Repositorys;

public interface IUserRoleRepository : IBaseRepository<UserRole>
{
    Task<List<UserRole>> GetById(UserRole entity);
    Task<List<int>> GetById(int userId);
    Task<List<string>> GetByIdJwt(int userId);
}

