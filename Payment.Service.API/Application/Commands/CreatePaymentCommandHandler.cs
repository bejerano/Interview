// using MediatR;

using Plooto.Assessment.Payment.Domain;

namespace Plooto.Assessment.Payment.API;

public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, bool>
{      
    private readonly IMediator _mediator;
    private readonly ILogger<CreatePaymentCommandHandler> _logger;
     private readonly IPaymentService _service;

    public CreatePaymentCommandHandler(IPaymentService service, IMediator mediator, ILogger<CreatePaymentCommandHandler> logger)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }


    /// <summary>
    /// This is the command handler for the CreatePaymentCommand
    /// </summary>
    /// <param name="request"> </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("---- Sending query: {request} ",request.BillId);

        var bills = await _service.GetBillByIdAsync(request.BillId);
        // This should be a Factory but I have time constraints
        // And the payment status should be changed like bills
        var newPayment = new PaymentDetail(request.Amount, DateTimeOffset.UtcNow, "submitted", (PaymentMethod)request.PaymentMethod);       

        await _service.PayBillAsync(bills, newPayment);
        _logger.LogInformation($"---- Coomand result: completed for BillId: {request.BillId}  ");

        return bills != null ? true : false;
    }
}

