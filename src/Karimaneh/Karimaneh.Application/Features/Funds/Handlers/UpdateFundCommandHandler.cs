using Common.Application.CQRS.Command;
using Common.Application.Exceptions;
using Karimaneh.Application.Features.Funds.Commands;
using Karimaneh.Application.Features.Funds.Specifications;
using Karimaneh.Domain.FundAgg.Repository;
using System.Text.Json;

namespace Karimaneh.Application.Features.Funds.Handlers
{
    public class UpdateFundCommandHandler : IBaseCommandHandler<UpdateFundCommand, bool>
    {
        private readonly IFundRepository _fundRepository;

        public UpdateFundCommandHandler(IFundRepository fundRepository)
        {
            _fundRepository = fundRepository;
        }

        public async Task<bool> Handle(UpdateFundCommand request, CancellationToken cancellationToken)
        {
            var fund = await _fundRepository.GetAllAsync(new FundGetAllSpec(), cancellationToken)
                ?? throw new NotFoundException("Fund Not Found!");

            var oldValue = JsonSerializer.Serialize(fund);

            fund.First().Edit(request.MaxConcurrentLoans,
                request.HasNoOverDueDebt,
                request.MinLoanAmount,
                request.MaxLoanAmount,
                request.MemberShipFee,
                request.InstallmentCount,
                request.GuaranteeType,
                request.BankInfo,
                request.UserId,
                oldValue
               );

            return await _fundRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
