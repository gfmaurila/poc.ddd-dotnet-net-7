using Auth.Domain.View.User;

namespace Auth.Domain.Contract.Repositorys.View;

public interface IViewUserRepository : IBaseRepository<ViewUserList>
{
    Task<ViewUserList> GetByName(string name);
    Task<List<ViewUserList>> SearchByName(string name);
    Task<ViewUserList> GetByAccountIdByProductIdById(int id);
}

