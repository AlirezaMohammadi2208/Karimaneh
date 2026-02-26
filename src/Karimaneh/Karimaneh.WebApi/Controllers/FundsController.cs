using AutoMapper;
using Karimaneh.Application.Features.Funds.Commands;
using Karimaneh.Application.Features.Funds.DTOs;
using Karimaneh.Application.Features.Funds.Queries;
using Karimaneh.WebApi.Extensions;
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
        private readonly IMapper _mapper;

        public FundsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET: api/Funds/Detail
        [HttpGet("Detail")]
        public async Task<ActionResult<IEnumerable<FundResponseDto>>> GetFundDetail(CancellationToken cancellationToken)
        {
            var fund = await _mediator.Send(new GetAllFundsQuery(), cancellationToken);
            return Ok(fund.First());
        }

        // PUT: api/Funds
        [HttpPut]
        public async Task<IActionResult> PutFund(UpdateFundRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateFundCommand>(request);
            command.UserId = User.GetUserId();

            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
