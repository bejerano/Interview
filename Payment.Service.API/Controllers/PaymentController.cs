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
        catch (Exception ex){
            _logger.LogError(ex, "---- Error getting billings");
            return BadRequest();
        }


    }

        [HttpGet()]
        [Route("{id:guid}")]
        [ProducesResponseType(typeof(IEnumerable<ViewModels.PaymentVM>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<object>> GetBillingAsync(Guid id)
        {

            //if (order == null)
            //{
            //    return NotFound();
            //}

            //if (order.BuyerId != _identityService.GetUserIdentity())
            //{
            //    return BadRequest();
            //}

            return Ok();
        }

        [HttpPost]
        [Route("payment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Guid>> AddPaymentAsync([FromBody] CreatePaymentCommand billing)
        {
            //var command = new CreateOrderCommand(billing.BuyerId, billing.BuyerName, billing.BuyerEmail, billing.Total);
            //var result = await _mediator.Send(command);

            //return CreatedAtAction(nameof(GetBillingAsync), new { id = result }, null);
            return Ok();
        }


    }