using AutoMapper;
using Karimaneh.Application.Features.Loans.DTOs;
using Karimaneh.Domain.LoanAgg;

namespace Karimaneh.Application.Features.Loans.Mappings
{
    public class InstallmentProfile : Profile
    {
        public InstallmentProfile()
        {
            CreateMap<Installment, InstallmentResponseDto>();
        }
    }
}
