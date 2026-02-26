using AutoMapper;
using Karimaneh.Application.Features.Requests.Command.ConfirmRequest;
using Karimaneh.Application.Features.Requests.DTOs;
using Karimaneh.Application.Features.Requests.Mapping;
using Karimaneh.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

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

        // PUT: api/Requests/5/confirm
        [HttpPut("{id}/confirm")]
        public async Task<IActionResult> PutRequestConfirm(Guid id, SetConfirmAppReqRequest dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<ConfirmRequestCommand>(dto);
            command.UserId = User.GetUserId();
            command.RequestId = id;

            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
