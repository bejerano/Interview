using MediatR;
using Plooto.Assessment.Payment.Application;

namespace Plooto.Assessment.Payment.API;

public class CreatePaymentCommand: IRequest<ViewModels.PaymentVM>
{
    public Guid BillId { get; private set; }



    public CreatePaymentCommand(Guid billId)
    {
        BillId = billId;
    }
}
