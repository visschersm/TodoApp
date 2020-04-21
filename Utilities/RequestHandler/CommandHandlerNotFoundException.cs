using System;

namespace MTech.Utilities.RequestHandler
{
    public class CommandHandlerNotFoundException : Exception
    {
        public CommandHandlerNotFoundException(Type type)
            : base($"CommandHandler: {type} not found")
        {
        }
    }
}
