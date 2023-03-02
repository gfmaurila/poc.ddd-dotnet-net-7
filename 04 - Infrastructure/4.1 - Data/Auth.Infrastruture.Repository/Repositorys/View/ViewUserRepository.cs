using Auth.Domain.Contract.Repositorys.View;
using Auth.Domain.View.User;
using Auth.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastruture.Repository.Repositorys;

public class ViewUserRepository : BaseRepository<ViewUserList>, IViewUserRepository
{
    private readonly EFContext _context;
    public ViewUserRepository(EFContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ViewUserList> GetByName(string name)
    {
        var find = await _context.ViewUserList.Where(x => x.UserName.ToLower() == name.ToLower()).AsNoTracking().ToListAsync();
        return find.FirstOrDefault();
    }

    public async Task<List<ViewUserList>> SearchByName(string name)
        => await _context.ViewUserList.Where(x => x.UserName.ToLower().Contains(name.ToLower())).AsNoTracking().ToListAsync();

    public async Task<ViewUserList> GetByAccountIdByProductIdById(int id)
    {
        var find = await _context.ViewUserList.Where(x => x.Id == id).AsNoTracking().ToListAsync();
        return find.FirstOrDefault();
    }

}


