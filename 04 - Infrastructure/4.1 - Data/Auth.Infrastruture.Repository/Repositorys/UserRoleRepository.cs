using Auth.Domain.Contract.Repositorys;
using Auth.Domain.Entities.Users;
using Auth.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastruture.Repository.Repositorys;

public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
{
    private readonly EFContext _context;
    public UserRoleRepository(EFContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<UserRole>> GetById(UserRole entity)
        => await _context.UserRole.Where(x => x.UserId == entity.UserId)
                         .AsNoTracking().ToListAsync();

    public async Task<List<int>> GetById(int userId)
        => await _context.UserRole.Where(x => x.UserId == userId)
                         .AsNoTracking().Select(s => s.Id).ToListAsync();

    public async Task<List<string>> GetByIdJwt(int userId)
        => await _context.UserRole.Where(x => x.UserId == userId)
                         .AsNoTracking().Select(s => s.Discriminator).ToListAsync();

}


