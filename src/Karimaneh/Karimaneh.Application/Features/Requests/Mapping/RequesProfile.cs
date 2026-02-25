using AutoMapper;
using Karimaneh.Application.Features.Requests.Command.CreateRequest;
using Karimaneh.Application.Features.Requests.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Application.Features.Requests.Mapping
{
    public class RequesProfile : Profile
    {
        public RequesProfile()
        {
            CreateMap<RequestCommandDto, CreateRequestCommand>();
        }
    }
}
