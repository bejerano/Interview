using Plooto.Assessment.Payment.Domain;

namespace Plooto.Assessment.Payment.Application;
public class PaymentVM
{
        public decimal  Amount {get; set;}
        public DateTimeOffset DebitDate {get; set;}
        public string Status {get; set;}
        public PaymentMethod Method {get; set;}

        public Guid BillId {get; set;}

}
