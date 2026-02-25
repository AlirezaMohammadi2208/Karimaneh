using AutoMapper;
using Karimaneh.Application.Features.Requests.DTOs;
using Karimaneh.Application.Features.Requests.Mapping;
using Karimaneh.Application.Features.Requests.Query.GetAllRequest;
using Karimaneh.Application.Features.Requests.Query.GetRequestById;
using Karimaneh.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Karimaneh.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public RequestsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateRequest(RequestCommandDto commandDto)
        {
            var command = commandDto.Mapping(User.GetUserId());

            var result = await _mediator.Send(command);
            if (result)
                return Ok();
            return BadRequest();
        }
        [HttpGet("{requestId}")]
        public async Task<ActionResult<RequestByIdDto>> GetRequestById(Guid requestId)
        {
            var result = await _mediator.Send(new GetRequestByIdQuery(requestId));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestByIdDto>>> GetRequests(CancellationToken cancellationToken, int limit = 25, int offset = 0)
        {
            var request = await _mediator.Send(new GetAllRequestQuery { Limit = limit, Offset = offset }, cancellationToken);
            return Ok(request);
        }
    }
}
