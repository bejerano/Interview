
using System.Linq.Expressions;
using Plooto.Assessment.Payment.Domain.Common;

namespace Plooto.Assessment.Payment.Application;

public class PaymentService : IPaymentService
{
    private readonly IRepository<Bill> _billRepository;

    public PaymentService(IRepository<Bill> billRepository)
    {
        _billRepository = billRepository ?? throw new ArgumentNullException(nameof(billRepository));
           
    }

    public Task<Bill> GetBillDetailAsync(Guid billId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Bill>> GetBillsAsync(Expression<Func<Bill, bool>>? filter = null,
            Func<IQueryable<Bill>, IOrderedQueryable<Bill>>? orderBy = null,
            string includeProperties = "")
    {
        var all = _billRepository.GetAsync(filter, orderBy, includeProperties);
        return all;
    }

    public Task PayBillAsync()
    {
        throw new NotImplementedException();
    }
}
