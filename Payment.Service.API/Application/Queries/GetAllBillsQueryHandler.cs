
namespace Plooto.Assessment.Payment.API;

public class GetAllBillsQueryHandler : IRequestHandler<GetAllBillsQuery, IEnumerable<ViewModels.BillVM>>
{
 
    private readonly ILogger<GetAllBillsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IPaymentService _service;

     public GetAllBillsQueryHandler(ILogger<GetAllBillsQueryHandler> logger, IMapper mapper, IPaymentService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }  
 
  
    /// <summary>
    /// Get all bills
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    async Task<IEnumerable<ViewModels.BillVM>> IRequestHandler<GetAllBillsQuery, IEnumerable<ViewModels.BillVM>>.Handle(GetAllBillsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("---- Sending query: {request} ",request);
        var bills = await _service.GetBillsAsync();

        var billVM = _mapper.Map<IEnumerable<ViewModels.BillVM>>(bills);
        _logger.LogInformation("---- Query result: Number of Bills gotten {request} ",billVM.Count());

        return billVM;
    }
}
