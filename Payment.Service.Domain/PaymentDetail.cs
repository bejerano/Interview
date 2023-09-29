namespace Plooto.Assessment.Payment.Domain
{

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
