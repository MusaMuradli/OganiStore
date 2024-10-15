using Ogani.DAL.DataContext.Entities;
using System;
using System.Linq.Expressions;

namespace Ogani.DAL.Repositories.Contracts;

public interface IRepository<T> : IQuery<T> where T : BaseEntity
{
    Task<T?> GetAsync(int id);
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(int id);
}
