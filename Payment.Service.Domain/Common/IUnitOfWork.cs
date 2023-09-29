namespace Plooto.Assessment.Payment.Domain.Common;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);    
    Task CommitTransactionAsync();
    void RollbackTransaction();
    // IRepository<T> Repository<T>() where T : PlootoEntity, new();
}