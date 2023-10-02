namespace Plooto.Assessment.Payment.API.Controllers;

[Route("api/v1/[controller]")]
// [Authorize]
[ApiController]
public class BillingController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<BillingController> _logger;

    public BillingController(
        IMediator mediator,
        ILogger<BillingController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }


    [HttpGet]
    [EnableQuery]
    [ProducesResponseType(typeof(IEnumerable<ViewModels.BillVM>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ViewModels.BillVM>>> GetBillingsAsync()
    {
        try
        {
            _logger.LogInformation("---- Get all billings request");
            var query = new GetAllBillsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "---- Error getting billings");
            return BadRequest();
        }


    }

    [HttpGet()]
    [Route("{id:guid}")]
    [ProducesResponseType(typeof(IEnumerable<ViewModels.PaymentVM>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> GetBillingAsync(Guid id)
    {

        try
        {
            _logger.LogInformation($"---- Get all payment history request: {id}");
            var query = new GetPaymentsByBillId(id);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"---- Error getting the history of payments for :{id}");
            return BadRequest();
        }


    }

    [HttpPost]
    [Route("payment")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> AddPaymentAsync([FromBody] CreatePaymentCommand payment)
    {
        try
        {
            _logger.LogInformation($"---- Add payment request: {payment.BillId}");
            var result = await _mediator.Send(payment);

            return CreatedAtAction(nameof(GetBillingAsync), new { id = result }, result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"---- Error adding payment for :{payment.BillId}");
            return BadRequest();
        }
    }  
}