namespace Plooto.Assessment.Payment.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : PlootoEntity, new()
{
    private readonly PaymentContext _context;
    public IUnitOfWork UnitOfWork => _context;

    internal DbSet<TEntity> dbSet;
    public Repository(PaymentContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        this.dbSet = context.Set<TEntity>();
    }
    public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
    {
        IQueryable<TEntity> query = dbSet;

        if (filter != null)
        {
            query = query.AsNoTracking().Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync();
        }
        else
        {
            return await query.ToListAsync();
        }
    }

    public virtual async Task<TEntity> GetByIDAsync(object id)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        return await dbSet.FindAsync(id);
    }

    public virtual async Task InsertAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
    }

    public virtual void Update(TEntity entityToUpdate)
    {
        dbSet.Attach(entityToUpdate);
        _context.Entry(entityToUpdate).State = EntityState.Modified;
    }

    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }


}

