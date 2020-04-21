using System;

namespace MTech.Utilities.RequestHandler
{
    public class QueryHandlerNotFoundException : Exception
    {
        public QueryHandlerNotFoundException(Type type)
            : base($"QueryHandler: {type} not found")
        {
        }
    }
}
