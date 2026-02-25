using Common.Application.CQRS.Command;
using Common.Domain.ValueObjects;
using Karimaneh.Application.Features.Identities.DTOs;
using Karimaneh.Application.Interfaces;
using Karimaneh.Domain.MemeberAgg;
using Karimaneh.Domain.MemeberAgg.Repository;
using Karimaneh.Domain.WalletAgg;
using Karimaneh.Domain.WalletAgg.Repository;

namespace Karimaneh.Application.Features.Members.Command.CreateMember
{
    public class CreateMemberCommandHandler : IBaseCommandHandler<CreateMemberCommand>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IIdentityService _identityService;
        public CreateMemberCommandHandler(IMemberRepository memberRepository, IWalletRepository walletRepository, IIdentityService identityService)
        {
            _memberRepository = memberRepository;
            _walletRepository = walletRepository;
            _identityService = identityService;
        }

        public async Task Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var wallet = Wallet.Create(WalletType.Member, request.UserId);
            await _walletRepository.AddAsync(wallet, cancellationToken);

            var member = Member.Create(request.fullName, new NationalCode(request.NationalCode)
                , request.FatherName, new BankInfo(request.AccountNumber, request.ShebaNumber, request.CardNumber)
                , request.AvatarName, request.LoanRequest, wallet.Id, DebtStatus.NotHave , request.UserId);
            await _memberRepository.AddAsync(member, cancellationToken);

            //TODO : Password Bussiness
            var identityUser = new RegisterRequestDto
            {
                MemberId = member.Id,
                Username = member.NationalCode.Value,
                Password = $"Aa@{member.NationalCode.Value}",
            };
            await _identityService.RegisterAsync(identityUser);

            await _memberRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
