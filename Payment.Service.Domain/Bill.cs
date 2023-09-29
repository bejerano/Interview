
namespace Plooto.Assessment.Payment.Domain;

    public class Bill : PlootoEntity
{
    private int _identifier;
    private string _vendor;
    private DateTimeOffset _dueDate;
    private decimal _totalDue;
    private decimal _previousBalance;

    public Bill()
    {
        _identifier = 0;
        _vendor = string.Empty;
        _dueDate = DateTimeOffset.MinValue;
        _totalDue = 0;
        _previousBalance = 0;        
    }
    
    public Bill(int identifier, string vendor, DateTimeOffset dueDate, decimal totalDue, decimal previousBalance)
    {
        _identifier = identifier;
        _vendor = vendor;
        _dueDate = dueDate;
        _totalDue = totalDue;
        _previousBalance = previousBalance;
    }

    public IEnumerable<PaymentDetail> BillPayments { get; set; }

    public int GetIdentifier()
    {
        return _identifier;
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


}





