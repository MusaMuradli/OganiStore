using Microsoft.EntityFrameworkCore;
using Ogani.DAL.DataContext;
using Ogani.DAL.DataContext.Entities;
using Ogani.DAL.Repositories.Contracts;
using System.Linq.Expressions;

namespace Ogani.DAL.Repositories;

public class EfCoreRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;


    public EfCoreRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
    {
        //var query = Query();
        //if (predicate != null)
        //    query = query.Where(predicate);
        //var result = await query.ToListAsync();

        //return result;
        IQueryable<T> query = _context.Set<T>();

        if (predicate != null)
            query = query.Where(predicate);
        var result = await query.ToListAsync();

        return result;
    }

    public async Task<T?> GetAsync(int id)
    {
        var query = Query();
        var result = await query.FirstOrDefaultAsync(x => x.Id == id);

        return result;
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
    {
        var query = Query();
        var result = await query.FirstOrDefaultAsync(predicate);

        return result;
    }

    public async Task<T> CreateAsync(T entity)
    {
        var entityEntry = await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public Task<T> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
    public Task<T> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> Query()
    {
        return _context.Set<T>();
    }
}
