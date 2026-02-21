using MediatR;

namespace Common.Application.CQRS.Query
{
    public interface IBaseQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IBaseQuery<TResponse>
    {

    }
}
