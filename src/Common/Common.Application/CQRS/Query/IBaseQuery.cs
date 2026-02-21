using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Application.CQRS.Query
{
    public interface IBaseQuery<TResponse> : IRequest<TResponse>
    {
    }
}
