using System.Linq.Expressions;

namespace Plooto.Assessment.Payment.Application;

public interface IPaymentService
{
    Task<IEnumerable<Bill>> GetBillsAsync(Expression<Func<Bill, bool>>? filter = null,
            Func<IQueryable<Bill>, IOrderedQueryable<Bill>>? orderBy = null,
            string includeProperties = "");
    Task<Bill> GetBillByIdAsync(Guid billId);        
    Task<IEnumerable<PaymentDetail>> GetBillDetailAsync(Guid billId);
    Task PayBillAsync(Bill bill, PaymentDetail payment);
}
