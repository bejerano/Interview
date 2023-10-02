using MediatR;
using Plooto.Assessment.Payment.Application;

namespace Plooto.Assessment.Payment.API;

public class CreatePaymentCommand: IRequest<bool>
{
    public Guid BillId { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime DebitDate { get; private set; }
    public int PaymentMethod { get; private set; }



    public CreatePaymentCommand(Guid billId, decimal amount, DateTime debitDate, int paymentMethod)
    {
        this.BillId = billId;
        this.Amount = amount;
        this.DebitDate = debitDate;
        this.PaymentMethod = paymentMethod;
    }
     
}
