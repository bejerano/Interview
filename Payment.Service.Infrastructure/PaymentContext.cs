
using System.Data;

namespace Plooto.Assessment.Payment.Infrastructure;

public class PaymentContext : DbContext, IUnitOfWork
{

    public const string DEFAULT_SCHEMA = "billing";
    public DbSet<Bill>? Bills { get; set; }
    public DbSet<PaymentDetail>? Payments { get; set; }
    public DbSet<BillStatus>? BillStatuses { get; set; }


    private IDbContextTransaction? _currentTransaction;


    public PaymentContext(DbContextOptions<PaymentContext> options) : base(options) {        
        _currentTransaction = null;       
        ChangeTracker.LazyLoadingEnabled = false;
    }
       
    public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

    public bool HasActiveTransaction => _currentTransaction != null;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PaymentEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BillEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BillStatusEntityTypeConfiguration());      
    }

    public async Task<IDbContextTransaction?> BeginTransactionAsync()
    {
        if (_currentTransaction != null) 
        return null;

        _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        return _currentTransaction;
    }

    private async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        if (transaction == null) throw new ArgumentNullException(nameof(transaction));
        if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

        try
        {
            await SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }

    public void RollbackTransaction()
    {
        try
        {
            _currentTransaction?.Rollback();
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }

    public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task CommitTransactionAsync()
    {
      await this.CommitTransactionAsync(_currentTransaction);
    }
}
