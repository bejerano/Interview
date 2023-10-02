using System;
using System.Reflection.Metadata;



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

     public async Task<Bill> GetBillByIdAsync(Guid billId){
        var bill = await _billRepository.GetByIDAsync(billId, "BillStatus,BillPayments");
        return bill;
     }


    /// <summary>
    /// Pay a bill
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task PayBillAsync(Bill bill, PaymentDetail payment)
    {
        if (bill == null)
        {
            throw new ArgumentNullException(nameof(bill));
        }

        if (payment == null)
        {
            throw new ArgumentNullException(nameof(payment));
        }
        // Needs Transaction lock 
        try {
          await this._billRepository.UnitOfWork.ExecuteTransaction(ExecutePayBillAsync(bill, payment));
        //   await this._billRepository.UnitOfWork.SaveChangesAsync();
        //   await this._billRepository.UnitOfWork.SaveChangesAsync();
                 
        }
        catch(Exception ex){
            this._billRepository.UnitOfWork.RollbackTransaction();
            throw ex;
        }

        if (bill.BillStatus.CompareTo(BillStatus.Overdue) == 0)
            throw  new PaymentOverdueException();
    }

    private Func<Task> ExecutePayBillAsync(Bill bill, PaymentDetail payment)
    {
        Func<Task> action = async () =>
        {
            try
            {
                // Ideally this would be a Strategy pattern to deal with this Code Smell
                // 1. Check if the bill is already paid
                if (bill.BillStatus.CompareTo(BillStatus.Paid) == 0)
                {
                    throw new Exception("The bill is already paid");
                }

                // 3. Check if the bill is partially paid or unpaid
                if ( bill.BillStatus.CompareTo(BillStatus.Partially_Paid) ==0 || 
                     bill.BillStatus.CompareTo(BillStatus.Unpaid) == 0 || 
                     bill.BillStatus.CompareTo(BillStatus.Overdue)==0 ) 
                {
                    // 3.1 Check if the bill is overdue
                    bill.Pay(payment.GetAmount());
                    bill.BillPayments.Add(payment);
                    bill.SetBillPaidStatus();                    

                    this._billRepository.Update(bill);  
                    await _billRepository.UnitOfWork.SaveChangesAsync();
                }     
            }
            catch (Exception ex)
            {
                // Handle the exception or log it, if necessary
                // For example: Logger.LogError(ex, "Error occurred while processing payment.");
                throw; // Re-throw the exception to propagate it upwards if needed
            }
        };

        return action;
    }
}
