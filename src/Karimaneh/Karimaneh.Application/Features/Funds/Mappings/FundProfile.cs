using AutoMapper;
using Karimaneh.Application.Features.Funds.Commands;
using Karimaneh.Application.Features.Funds.DTOs;
using Karimaneh.Domain.FundAgg;

namespace Karimaneh.Application.Features.Funds.Mappings
{
    public class FundProfile : Profile
    {
        public FundProfile()
        {
            CreateMap<Fund, FundResponseDto>();
            CreateMap<UpdateFundRequest, UpdateFundCommand>();
        }
    }
}
