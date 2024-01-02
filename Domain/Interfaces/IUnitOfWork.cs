
namespace Domain.Interfaces;

public interface IUnitOfWork
{
    Task Commit(CancellationToken cancellationToken);
    Task RoolBack(CancellationToken cancellationToken);
}
