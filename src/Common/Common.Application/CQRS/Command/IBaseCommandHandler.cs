using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Application.CQRS.Command
{
    public interface IBaseCommandHandler<TCommand> : IRequestHandler<TCommand> where TCommand :IBaseCommand
    {
    }
    public interface IBaseCommandHandler<TCommand , TResponse> : IRequestHandler<TCommand , TResponse> 
        where TCommand : IBaseCommand<TResponse>
    {

    }
}
