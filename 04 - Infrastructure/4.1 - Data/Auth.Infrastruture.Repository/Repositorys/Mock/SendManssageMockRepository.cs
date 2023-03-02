using Auth.Domain.Contract.Repositorys.Mock;
using Auth.Domain.Entities.Mock;
using Auth.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastruture.Repository.Repositorys.Mock;

public class SendManssageMockRepository : ISendManssageMockRepository
{
    private readonly EFContext _context;
    public SendManssageMockRepository(EFContext context)
    {
        _context = context;
    }
    public async Task AddAsync(SendManssageMock entity)
    {
        await _context.SendManssageMock.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<SendManssageMock>> GetAllAsync()
        => await _context.SendManssageMock.ToListAsync();

    public Task<SendManssageMock> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();

    public Task StartAsync(int id)
    {
        throw new NotImplementedException();
    }
}


