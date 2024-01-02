using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContext;

namespace Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly FuelPointerDbContext _context;
    public BaseRepository(FuelPointerDbContext fuel)
    {
        _context= fuel;
    }
    public async Task Create(T entity)
    {
        entity.DateCreated = DateTimeOffset.UtcNow;
        _context.Add(entity);
    }
    public async Task Update(T entity)
    {
        entity.DateUpdate = DateTimeOffset.UtcNow;
        _context.Update(entity);
    }
    public async Task Delete(T entity)
    {
       entity.DateDeleted = DateTimeOffset.UtcNow;
        _context.Remove(entity);
    }

    public async Task<T> Get(Guid id, CancellationToken cancellationToken)
    {
       return await _context.Set<T>().FirstOrDefaultAsync(x=>x.id==id,cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

   
}
