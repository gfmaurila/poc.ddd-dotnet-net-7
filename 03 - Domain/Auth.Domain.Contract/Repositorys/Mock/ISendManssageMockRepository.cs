using Auth.Domain.Entities.Mock;

namespace Auth.Domain.Contract.Repositorys.Mock;

public interface ISendManssageMockRepository
{
    Task<List<SendManssageMock>> GetAllAsync();
    Task<SendManssageMock> GetByIdAsync(int id);
    Task AddAsync(SendManssageMock entity);
    Task StartAsync(int id);
    Task SaveChangesAsync();
}
