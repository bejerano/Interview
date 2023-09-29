using MediatR;

namespace Plooto.Assessment.Payment.API;

public class GetAllBillsQuery: IRequest<IEnumerable<BillVM>> 
{ 
    // Add all the filters and sorting properties here
}
 