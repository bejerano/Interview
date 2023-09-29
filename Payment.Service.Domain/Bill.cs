
namespace Plooto.Assessment.Payment.Domain
{
    public class Bill : PlootoEntity
    {
        private int _identifier;
        private string _vendor;
        private DateTimeOffset _dueDate;
        private decimal _totalDue;
        private decimal _previousBalance;

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

    public class PaymentDetail : PlootoEntity
    {
        // Patterns comment
        // Using private fields, is a much better encapsulation 

        private decimal _amount;
        private DateTimeOffset _debitDate;
        private string _status;
        private PaymentMethod _method;

        public PaymentDetail(decimal amount, DateTimeOffset debitDate, string status, PaymentMethod method)
        {

            _amount = amount;
            _debitDate = debitDate;
            _status = status;
            _method = method;
            
        }

        private Guid BillId { get; }
        private Bill Bill { get; set; }

        public decimal GetAmount()
        {
            return _amount;
        }

        public DateTimeOffset GetDebitDate()
        {
            return _debitDate;
        }

        public string GetStatus()
        {
            return _status;
        }

        public PaymentMethod GetMethod()
        {
            return _method;
        }     

    }
}

