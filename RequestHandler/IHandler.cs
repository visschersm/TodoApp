using System.Threading.Tasks;

namespace MTech.RequestHandler
{
    public interface IQueryHandler<TRequest, TResponse>
    {
        public Task<TResponse> HandleAsync(TRequest request);
    }

    public interface ICommandHandler<TRequest>
        where TRequest : IRequest
    {
        public Task<IRequestResult> HandleAsync(TRequest request);
    }

    public interface IHandler
    {
        Task<TResponse> HandleQueryAsync<TRequest, TResponse>(TRequest request) where TRequest : IRequest;
        Task<IRequestResult> HandleCommandAsync<TRequest>(TRequest request) where TRequest : IRequest;
    }
}
