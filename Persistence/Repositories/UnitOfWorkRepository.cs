using Domain.Interfaces;
using Persistence.DataContext;
namespace Persistence.Repository;

public class UnitOfWorkRepository:IUnitOfWork
{
    private readonly FuelPointerDbContext _context;
	public UnitOfWorkRepository(FuelPointerDbContext fuelPointerDbContext)
	{
        _context= fuelPointerDbContext;
	}

    public async Task Commit(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public Task RoolBack(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
