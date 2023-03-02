using Auth.Domain.Contract.Repositorys;
using Auth.Domain.Entities.Users;
using Auth.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastruture.Repository.Repositorys;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly EFContext _context;
    public UserRepository(EFContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetByName(string name)
    {
        var find = await _context.User.Where(x => x.UserName.ToLower() == name.ToLower()).AsNoTracking().ToListAsync();
        return find.FirstOrDefault();
    }

    public async Task<User> GetByNameById(User entity)
    {
        var find = await _context.User.Where(x => x.UserName.ToLower() == entity.UserName.ToLower()).AsNoTracking().ToListAsync();
        return find.FirstOrDefault();
    }

    public async Task<List<User>> SearchByName(string name)
        => await _context.User.Where(x => x.UserName.ToLower().Contains(name.ToLower())).AsNoTracking().ToListAsync();

}


