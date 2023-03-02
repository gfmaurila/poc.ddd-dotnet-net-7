using Auth.Domain.Entities.Users;

namespace Auth.Domain.Contract.Repositorys;

public interface IUserCodeResetRepository : IBaseRepository<UserCodeReset>
{
    Task<UserCodeReset> GetByCodeStatus(string code);
}

