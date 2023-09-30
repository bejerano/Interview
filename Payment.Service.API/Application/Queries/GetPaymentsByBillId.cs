
namespace Plooto.Assessment.Payment.API;

public class GetPaymewntsByBillId: IRequest<IEnumerable<ViewModels.PaymentVM>> 
{ 
    // Add all the filters and sorting properties here
    public Guid BillId { get; set; }
}
 