using Auth.Domain.Contract.Repositorys;
using Auth.Domain.Entities;
using Auth.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastruture.Repository.Repositorys;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly EFContext _context;

    public BaseRepository(EFContext context)
    {
        _context = context;
    }

    public virtual async Task<T> Create(T obj)
    {
        obj.Modified = DateTime.Now;
        _context.Add(obj);
        await _context.SaveChangesAsync();

        return obj;
    }

    public virtual async Task<T> Update(T obj)
    {
        obj.Modified = DateTime.Now;
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return obj;
    }

    public virtual async Task<bool> Remove(int id)
    {
        var obj = await Get(id);

        if (obj != null)
        {
            _context.Remove(obj);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public virtual async Task<T> Get(int id)
    {
        var obj = await _context.Set<T>()
                                .AsNoTracking()
                                .Where(x => x.Id == id)
                                .ToListAsync();

        return obj.FirstOrDefault();
    }

    public virtual async Task<List<T>> Get()
    {
        return await _context.Set<T>()
                             .AsNoTracking()
                             .ToListAsync();
    }
}
