using System.Linq.Expressions;
using Plooto.Assessment.Payment.Domain;
using Plooto.Assessment.Payment.Infrastructure.Repositories;

namespace Plooto.Assessment.Payment.Infrastructure;

public class Repository<TEntity>: IRepository<TEntity>, IDisposable where TEntity : PlootoEntity, new() 
{
    private readonly PaymentContext _context;
     internal DbSet<TEntity> dbSet;

    public IUnitOfWork UnitOfWork => _context;

    public Repository(PaymentContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
         this.dbSet = context.Set<TEntity>();
    }
    public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

    public void Dispose()
    {
        throw new NotImplementedException();
    }


}
 
