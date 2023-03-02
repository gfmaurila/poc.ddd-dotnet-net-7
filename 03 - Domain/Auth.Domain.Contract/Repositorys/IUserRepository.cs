using Auth.Domain.Entities.Users;

namespace Auth.Domain.Contract.Repositorys;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByName(string name);
    Task<List<User>> SearchByName(string name);
    Task<User> GetByNameById(User entity);
}

