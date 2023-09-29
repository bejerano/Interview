using System.Linq.Expressions;

namespace Plooto.Assessment.Payment.Domain.Common; 

public interface IRepository<T> : IDisposable where T : PlootoEntity, new()
{
    IUnitOfWork UnitOfWork { get; }
    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "");

    Task<T> GetByIDAsync(object id);
    Task InsertAsync(T entity);
    void Update(T entityToUpdate);   
}