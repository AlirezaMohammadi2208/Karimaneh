using Karimaneh.Application.Features.Funds.DTOs;
using Karimaneh.Application.Features.Funds.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Karimaneh.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy = "Accessibility")]
    public class FundsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FundsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Funds/Detail
        [HttpGet("Detail")]
        public async Task<ActionResult<IEnumerable<FundResponseDto>>> GetFundDetail(CancellationToken cancellationToken)
        {
            var fund = await _mediator.Send(new GetAllFundsQuery(), cancellationToken);
            return Ok(fund.First());
        }
    }
}
