
namespace Plooto.Assessment.Payment.Domain;

    public class Bill : PlootoEntity
{
    private int _identifierUI;
    private string _vendor;
    private DateTimeOffset _dueDate;
    private decimal _totalDue;
    private decimal _previousBalance;
    private int _billStatusId;

    public Bill()
    {
        _identifierUI = 0;
        _vendor = string.Empty;
        _dueDate = DateTimeOffset.MinValue;
        _totalDue = 0;
        _previousBalance = 0;        
    }
    
    public Bill(int identifier, string vendor, DateTimeOffset dueDate, decimal totalDue, decimal previousBalance)
    {
        _identifierUI = identifier;
        _vendor = vendor;
        _dueDate = dueDate;
        _totalDue = totalDue;
        _previousBalance = previousBalance;
        _billStatusId = BillStatus.Unpaid.Id;
    }

    public virtual ICollection<PaymentDetail> BillPayments { get; set; }
    public virtual BillStatus BillStatus { get; private set; }
   

    public int GetIdentifier()
    {
        return _identifierUI;
    }

    public string GetVendor()
    {
        return _vendor;
    }

    public DateTimeOffset GetDueDate()
    {
        return _dueDate;
    }

    public decimal GetTotalDue()
    {
        return _totalDue;
    }

    public decimal GetPreviousBalance()
    {
        return _previousBalance;
    }

   

    public void SetBillPaidStatus()
    {
        if (_billStatusId == BillStatus.Partially_Paid.Id && _previousBalance == 0)        
        {
            _billStatusId = BillStatus.Paid.Id;
        }
    }

    public void SetBillPartiallyPaidStatus()
    {
        if (_billStatusId == BillStatus.Unpaid.Id && _previousBalance > 0) 
        {        
            _billStatusId = BillStatus.Partially_Paid.Id;
        }
    }

    public void SetBillOverdueStatus()
    {
        if ((_billStatusId == BillStatus.Unpaid.Id || _billStatusId == BillStatus.Partially_Paid.Id) && DateTimeOffset.Compare (_dueDate,DateTimeOffset.Now) < 0)
        {
            _billStatusId = BillStatus.Overdue.Id;
        }
    }

    public void Pay(decimal amount)
    {
        if (amount > 0)
        {
            _previousBalance = _previousBalance - amount;
        }
        SetBillOverdueStatus();
    }
}





