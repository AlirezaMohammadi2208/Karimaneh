using Karimaneh.Application.Features.Loans.DTOs;
using Karimaneh.Application.Features.Loans.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Karimaneh.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy = "Accessibility")]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Loans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanResponseDto>>> GetLoans(CancellationToken cancellationToken)
        {
            var loans = await _mediator.Send(new GetAllLoansQuery(), cancellationToken);
            return Ok(loans);
        }

        // GET: api/Loans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanResponseDto>> GetLoan(Guid id, CancellationToken cancellationToken)
        {
            var loan = await _mediator.Send(new GetLoanByIdQuery { Id = id }, cancellationToken);

            if (loan == null)
            {
                return NotFound();
            }

            return Ok(loan);
        }
    }
}
