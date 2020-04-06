using System.Threading.Tasks;

namespace MTech.RequestHandler
{
    public interface IQueryHandler<TQueryRequest, TQueryResult>
        where TQueryRequest : IQueryRequest
        where TQueryResult : IQueryResult
    {
        Task<TQueryResult> Handle(TQueryRequest request);
    }

    public interface ICommandHandler<TCommandRequest, TCommandResult>
        where TCommandRequest : ICommandRequest
        where TCommandResult : ICommandResult
    {
        Task<TCommandResult> Handle(TCommandRequest request);
    }

    public interface IHandler
    {
        Task<TQueryResult> HandleQuery<TQueryRequest, TQueryResult>(TQueryRequest request)
            where TQueryRequest : IQueryRequest
            where TQueryResult : IQueryResult;
        Task<TCommandResult> HandleCommand<TCommandRequest, TCommandResult>(TCommandRequest request)
            where TCommandRequest : ICommandRequest
            where TCommandResult : ICommandResult;
    }
}
