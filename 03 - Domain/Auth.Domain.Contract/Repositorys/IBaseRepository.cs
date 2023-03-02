using Auth.Domain.Entities;

namespace Auth.Domain.Contract.Repositorys;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> Create(T obj);
    Task<T> Update(T obj);
    Task<bool> Remove(int id);
    Task<T> Get(int id);
    Task<List<T>> Get();
}
