using AutoMapper;
using Karimaneh.Application.Features.Members.Command.CreateMember;
using Karimaneh.Application.Features.Members.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult> CreateMember([FromBody]CreateMemberRequestDto requestDto)
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
                new Guid("D1807F77-7A35-4420-8EFE-7123EF396D99")
                );
            await _mediator.Send(command);
            return Ok();
        }
    }
}
