using System.Threading.Tasks;

namespace MTech.Utilities.RequestHandler
{
    public interface IQueryHandler<TRequest, TResponse>
    {
        public Task<TResponse> HandleAsync(TRequest request);
    }

    public interface ICommandHandler<TCommandRequest, TCommandResult>
        where TCommandRequest : ICommandRequest
        where TCommandResult : ICommandResult
    {
        Task<TCommandResult> Handle(TCommandRequest request);
    }

    public interface IHandler
    {
        Task<TResponse> HandleQueryAsync<TRequest, TResponse>(TRequest request) where TRequest : IRequest;
        Task<TCommandResult> HandleCommand<TCommandRequest, TCommandResult>(TCommandRequest request)
            where TCommandRequest : ICommandRequest
            where TCommandResult : ICommandResult;
    }
}
