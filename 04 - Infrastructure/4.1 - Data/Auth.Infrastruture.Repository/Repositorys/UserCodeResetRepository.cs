using Auth.Domain.Contract.Repositorys;
using Auth.Domain.Entities.Users;
using Auth.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastruture.Repository.Repositorys;

public class UserCodeResetRepository : BaseRepository<UserCodeReset>, IUserCodeResetRepository
{
    private readonly EFContext _context;
    public UserCodeResetRepository(EFContext context) : base(context)
    {
        _context = context;
    }

    public async Task<UserCodeReset> GetByCodeStatus(string code)
    {
        var find = await _context.UserCodeReset.Where(x => x.Code ==  code  && x.Status == true).AsNoTracking().ToListAsync();
        return find.FirstOrDefault();
    }

}


