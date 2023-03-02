using Auth.Domain.Contract.Repositorys;
using Auth.Domain.Entities.Users;
using Auth.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastruture.Repository.Repositorys;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    private readonly EFContext _context;
    public RoleRepository(EFContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Role> GetByName(string name)
    {
        var find = await _context.Role.Where(x => x.Name.ToLower() == name.ToLower()).AsNoTracking().ToListAsync();
        return find.FirstOrDefault();
    }

    public async Task<Role> GetByNameById(Role entity)
    {
        var find = await _context.Role.Where(x => x.Name.ToLower() == entity.Name.ToLower()).AsNoTracking().ToListAsync();
        return find.FirstOrDefault();
    }

    public async Task<List<Role>> SearchByName(string name)
        => await _context.Role.Where(x => x.Name.ToLower().Contains(name.ToLower())).AsNoTracking().ToListAsync();

}


