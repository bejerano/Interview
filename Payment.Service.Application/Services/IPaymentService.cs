using System.Linq.Expressions;

namespace Plooto.Assessment.Payment.Application;

public interface IPaymentService
{
    Task<IEnumerable<Bill>> GetBillsAsync(Expression<Func<Bill, bool>>? filter = null,
            Func<IQueryable<Bill>, IOrderedQueryable<Bill>>? orderBy = null,
            string includeProperties = "");
    Task<Bill> GetBillDetailAsync(Guid billId);
    Task PayBillAsync ();
}
