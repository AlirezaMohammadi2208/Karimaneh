using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Application.CQRS.Command
{
    public interface IBaseCommand : IRequest
    {
    }
    public interface IBaseCommand<TResponse> : IRequest<TResponse>
    {

    }
    
}
