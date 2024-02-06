using Domain.Entities;


namespace Domain.Interfaces;

public interface IBaseRepository<T>where T:BaseEntity 
{
    Task Create(T entity);
    Task Delete(T entity);
    Task Update(T entity);
    Task<T> Get(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);
    
}
