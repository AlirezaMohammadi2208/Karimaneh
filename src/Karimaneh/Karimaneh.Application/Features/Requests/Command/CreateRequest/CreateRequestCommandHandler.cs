using Common.Application.CQRS.Command;
using Karimaneh.Domain.RequestAgg;
using Karimaneh.Domain.RequestAgg.Repository;

namespace Karimaneh.Application.Features.Requests.Command.CreateRequest
{
    public class CreateRequestCommandHandler : IBaseCommandHandler<CreateRequestCommand, bool>
    {
        private readonly IRequestRepository _requestRepository;
        public CreateRequestCommandHandler(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<bool> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            var newRequest = Request.Create(request.MemberId, request.Amount
                , request.Description, request.UserId);
            var guarantors = request.membersId.Select(x => Guarantor.Create(x, newRequest.Id)).ToList();
            newRequest.AddGuarantors(guarantors);
            await _requestRepository.AddAsync(newRequest, cancellationToken);
            return await _requestRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
    //TODO Validation
}
