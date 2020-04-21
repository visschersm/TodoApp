using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace MTech.Utilities.RequestHandler
{
    public class DefaultHandler : IHandler
    {
        private readonly IServiceProvider _serviceProvider;

        public DefaultHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TQueryResult> HandleQuery<TQueryRequest, TQueryResult>(TQueryRequest request)
            where TQueryRequest : IQueryRequest
            where TQueryResult : IQueryResult
        {
            var handler = _serviceProvider.GetService<IQueryHandler<TQueryRequest, TQueryResult>>();

            if (!((handler != null) && handler is IQueryHandler<TQueryRequest, TQueryResult>))
            {
                throw new QueryHandlerNotFoundException(typeof(TQueryRequest));
            }

            return await handler.Handle(request);

        }

        public async Task<TCommandResult> HandleCommand<TCommandRequest, TCommandResult>(TCommandRequest request)
            where TCommandRequest : ICommandRequest
            where TCommandResult : ICommandResult
        {
            var handler = _serviceProvider.GetService<ICommandHandler<TCommandRequest, TCommandResult>>();
            if (!((handler != null) && handler is ICommandHandler<TCommandRequest, TCommandResult>))
            {
                throw new CommandHandlerNotFoundException(typeof(TCommandRequest));
            }
            return await handler.Handle(request);
        }
    }
}