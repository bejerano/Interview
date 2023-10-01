
namespace Plooto.Assessment.Payment.API;

public class GetPaymentsByBillId: IRequest<IEnumerable<ViewModels.PaymentVM>> 
{
    public GetPaymentsByBillId(Guid billId)
    {
        BillId = billId;
    }

    // Add all the filters and sorting properties here
    public Guid BillId { get; private set; }
}
 