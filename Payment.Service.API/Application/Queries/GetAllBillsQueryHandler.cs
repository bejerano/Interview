using AutoMapper;
using MediatR;
using Plooto.Assessment.Payment.Application;

namespace Plooto.Assessment.Payment.API;

public class GetAllBillsQueryHandler : IRequestHandler<GetAllBillsQuery, IEnumerable<BillVM>>
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

    async Task<IEnumerable<BillVM>> IRequestHandler<GetAllBillsQuery, IEnumerable<BillVM>>.Handle(GetAllBillsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("---- Sending query: {request} ",request);
        var bills = await _service.GetBillsAsync();

        var billVM = _mapper.Map<IEnumerable<BillVM>>(bills);
        _logger.LogInformation("---- Query result: Number of Bills gotten {request} ",billVM.Count());

        return billVM;
    }
}
