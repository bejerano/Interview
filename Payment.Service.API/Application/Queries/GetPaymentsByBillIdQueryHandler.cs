
namespace Plooto.Assessment.Payment.API;

public class GetPaymentsByBillIdQueryHandler : IRequestHandler<GetPaymentsByBillId, IEnumerable<ViewModels.PaymentVM>>
{
    private readonly ILogger<GetPaymentsByBillIdQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IPaymentService _service;

     public GetPaymentsByBillIdQueryHandler(ILogger<GetPaymentsByBillIdQueryHandler> logger, IMapper mapper, IPaymentService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }  

    /// <summary>
    /// Get all payments for a bill
    /// </summary>
    /// <param name="request"> the request containg the bill id </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<ViewModels.PaymentVM>> Handle(GetPaymentsByBillId request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("---- Sending query: {request} ",request);
        var payments = await _service.GetBillDetailAsync(request.BillId);

        var paymentVM = _mapper.Map<IEnumerable<ViewModels.PaymentVM>>(payments);
        _logger.LogInformation("---- Query result: Number of Payments gotten {request} ",paymentVM.Count());

        return paymentVM;
    }
}
