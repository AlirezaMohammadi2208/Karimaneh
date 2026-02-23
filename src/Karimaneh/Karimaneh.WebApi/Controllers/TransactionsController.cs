using AutoMapper;
using Karimaneh.Application.Extensions;
using Karimaneh.Application.Features.Transactions.Commands;
using Karimaneh.Application.Features.Transactions.DTOs;
using Karimaneh.Application.Features.Transactions.Queries;
using Karimaneh.Application.Idempotency;
using Karimaneh.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Karimaneh.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy = "Accessibility")]
    public class TransactionsController : ControllerBase
    {

        private readonly ILogger<TransactionsController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TransactionsController(ILogger<TransactionsController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionResponseDto>>> GetTransactions(CancellationToken cancellationToken, int limit = 25, int offset = 0)
        {
            var transaction = await _mediator.Send(new GetAllTransactionsQuery { Limit = limit, Offset = offset }, cancellationToken);
            return Ok(transaction);
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionResponseDto>> GetTransaction(Guid id, CancellationToken cancellationToken)
        {
            var transaction = await _mediator.Send(new GetTransactionByIdQuery { Id = id }, cancellationToken);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        // POST: api/Transactions
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<TransactionResponseDto>> PostTransaction(CreateTransactionRequestDto createTransactionRequestDto, [FromHeader(Name = "x-requestid")] Guid requestId, CancellationToken cancellationToken)
        {
            if (requestId == Guid.Empty)
            {
                return BadRequest("Empty GUID is not valid for request ID");
            }

            using (_logger.BeginScope(new List<KeyValuePair<string, object>> { new("IdentifiedCommandId", requestId) }))
            {
                var command = _mapper.Map<CreateTransactionCommand>(createTransactionRequestDto);
                command.UserId = User.GetUserId();

                var requestCreateTransaction = new IdentifiedCommand<CreateTransactionCommand, bool>(command, requestId);

                _logger.LogInformation(
                    "Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    requestCreateTransaction.GetGenericTypeName(),
                    nameof(requestCreateTransaction.Id),
                    requestCreateTransaction.Id,
                    requestCreateTransaction);

                var result = await _mediator.Send(requestCreateTransaction, cancellationToken);

                if (result)
                {
                    _logger.LogInformation("CreateTransactionCommand succeeded - RequestId: {RequestId}", requestId);
                    return Created();
                }
                else
                {
                    _logger.LogWarning("CreateTransactionCommand failed - RequestId: {RequestId}", requestId);
                    return BadRequest();
                }
            }
        }

        // PUT: api/Transactions/5/confirm
        [HttpPut("{id}/confirm")]
        [Authorize]
        public async Task<IActionResult> PutTransactionConfirm(Guid id, CancellationToken cancellationToken)
        {
            var command = new SetConfirmTransactionComand { Id = id, UserId = User.GetUserId() };

            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
