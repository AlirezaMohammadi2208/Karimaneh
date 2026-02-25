using AutoMapper;
using Karimaneh.Application.Features.Members.Command.CreateMember;
using Karimaneh.Application.Features.Members.DTOs;
using Karimaneh.Domain.MemeberAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Application.Features.Members.Mapping
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Member, MemberResponseDto>();
            CreateMap<CreateMemberRequestDto, CreateMemberCommand>();
        }
    }
}
