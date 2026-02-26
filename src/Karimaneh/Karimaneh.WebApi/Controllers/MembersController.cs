using AutoMapper;
using Karimaneh.Application.Features.Members.Command.ActiveMember;
using Karimaneh.Application.Features.Members.Command.CreateMember;
using Karimaneh.Application.Features.Members.Command.DeActiveMember;
using Karimaneh.Application.Features.Members.Command.UpdateMember;
using Karimaneh.Application.Features.Members.DTOs;
using Karimaneh.Application.Features.Members.Query.GetAllMembers;
using Karimaneh.Application.Features.Members.Query.GetMemberById;
using Karimaneh.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Karimaneh.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public MembersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> CreateMember([FromBody] CreateMemberRequestDto requestDto)
        {
            var command = new CreateMemberCommand(
                requestDto.FullName,
                requestDto.NationalCode,
                requestDto.FatherName,
                requestDto.ShebaNumber,
                requestDto.AccountNumber,
                requestDto.CardNumber,
                requestDto.AvatarName,
                requestDto.LoanRequest,
                User.GetUserId(),
                requestDto.phoneNumber
                );
            await _mediator.Send(command);
            return Ok();
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberResponseDto>>> GetMembers(CancellationToken cancellationToken, int limit = 25, int offset = 0)
        {
            var members = await _mediator.Send(new GetAllMembersQuery { Limit = limit, Offset = offset }, cancellationToken);

            return Ok(members);
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberResponseDto>> GetMember(Guid id, CancellationToken cancellationToken)
        {
            var member = await _mediator.Send(new GetMemberByIdQuery { Id = id }, cancellationToken);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        // PUT: api/Members/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(Guid id, UpdateMemberRequestDto dto, CancellationToken cancellationToken)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var command = _mapper.Map<UpdateMemberCommand>(dto);
            command.UserId = User.GetUserId();

            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        // PUT: api/Members/5/active
        [HttpPut("{id}/active")]
        public async Task<IActionResult> PutMemberActive(Guid id, CancellationToken cancellationToken)
        {
            var command = new SetActiveMemberCommand { Id = id, UserId = User.GetUserId() };
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        // PUT: api/Members/5/deactive
        [HttpPut("{id}/deactive")]
        public async Task<IActionResult> PutMemberDeActive(Guid id, CancellationToken cancellationToken)
        {
            var command = new SetDeActiveMemberCommand { Id = id, UserId = User.GetUserId() };
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
