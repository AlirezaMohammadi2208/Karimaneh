using AutoMapper;
using Karimaneh.Application.Features.Transactions.Commands;
using Karimaneh.Application.Features.Transactions.DTOs;
using Karimaneh.Domain.TransactionAgg;

namespace Karimaneh.Application.Features.Transactions.Mappings
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionResponseDto>();

            CreateMap<CreateTransactionRequestDto, CreateTransactionCommand>();
        }
    }
}
