using MediatR;

namespace Common.Application.CQRS.Query
{
    public interface IBaseQuueryHandler<TQuery , TResponse>: IRequestHandler<TQuery , TResponse> 
        where TQuery : IBaseQuery<TResponse>
    {

    }
}
