using AutoMapper;
using Karimaneh.Application.Features.Loans.DTOs;
using Karimaneh.Domain.LoanAgg;

namespace Karimaneh.Application.Features.Loans.Mappings
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<Loan, LoanResponseDto>();


        }
    }
}
