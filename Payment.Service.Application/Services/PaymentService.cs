
using System.Linq;
using System.Linq.Expressions;
using Plooto.Assessment.Payment.Domain.Common;

namespace Plooto.Assessment.Payment.Application;

public class PaymentService : IPaymentService
{
    private readonly IRepository<Bill> _billRepository;
    private readonly IRepository<PaymentDetail> _paymentRepository;

    public PaymentService(IRepository<Bill> billRepository, IRepository<PaymentDetail> paymentRepository)
    {
        _billRepository = billRepository ?? throw new ArgumentNullException(nameof(billRepository));
        _paymentRepository = paymentRepository ?? throw new ArgumentNullException(nameof(paymentRepository)); ;
    }


    /// <summary>
    /// Get all payments for a bill
    /// </summary>
    /// <param name="billId"></param>
    /// <returns> List of payments associated to the Bill</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<IEnumerable<PaymentDetail>> GetBillDetailAsync(Guid billId)
    {       
        if (billId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(billId));
        }

        /**
        * Note: This is a shortcut to get all payments with bill, but the correct way of doing
        * this is using Materialize Pattern (a.k.a: Flatten the table)
        * eg. dbContext.Database.SqlQuery<PaymentDetail>("EXEC YourStoredProcedure @BillId", billId);
        */        
        Expression<Func<PaymentDetail, bool>> filterExpression =  (x => x.GetBillId() == billId);        
        var all = await this._paymentRepository.GetAsync();        
        var only = all.AsQueryable().Where(filterExpression);

        return only;
    }


    /// <summary>
    /// Get all bills
    /// </summary>
    /// <param name="filter"> Expression that filters the data</param>
    /// <param name="orderBy"> Column to Order</param>
    /// <param name="includeProperties"> List of properties that allow to load the reltions with EF</param>
    /// <returns></returns>
    public Task<IEnumerable<Bill>> GetBillsAsync(Expression<Func<Bill, bool>>? filter = null,
            Func<IQueryable<Bill>, IOrderedQueryable<Bill>>? orderBy = null,
            string includeProperties = "")
    {
        /** 
        * Note: This is a shortcut to get all bills with status, but the correct way of doing 
        * this is using Materialize Pattern (a.k.a: Flatten the table)
        * Because of time I am not implementing this pattern
        */
        var all = _billRepository.GetAsync(filter, orderBy, "BillStatus");
        return all;
    }


    /// <summary>
    /// Pay a bill
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task PayBillAsync()
    {
        throw new NotImplementedException();
    }
}
