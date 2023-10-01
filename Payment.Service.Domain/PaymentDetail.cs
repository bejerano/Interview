namespace Plooto.Assessment.Payment.Domain
{

    public class PaymentDetail : PlootoEntity
    {
        // Patterns comment
        // Using private fields, is a much better encapsulation 
        private int _identifier;
        private decimal _amount;
        private DateTimeOffset _debitDate;
        private string _status;
        private PaymentMethod _method;

        public PaymentDetail()
        {
            _amount = 0;
            _debitDate = DateTimeOffset.MinValue;
            _status = string.Empty;
            _method = PaymentMethod.CreditCard;
            _identifier = 0;
        }

        public PaymentDetail(decimal amount, DateTimeOffset debitDate, string status, PaymentMethod method, int identifier)
        {
            _amount = amount;
            _debitDate = debitDate;
            _status = status;
            _method = method;
            _identifier = identifier;
        }

        private Guid BillId { get; }
        public virtual Bill Bill { get; private set; }

        public Guid GetBillId()
        {
            return BillId;
        }

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

        public int GetIdentifier()
        {
            return _identifier;
        }

    }
}
