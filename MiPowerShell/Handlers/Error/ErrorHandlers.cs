using MiPowerShell.Handlers.Commands;
using MiPowerShell.Helpers;

namespace MiPowerShell.Handlers.Error
{
    internal class ErrorHandlers
    {
        private readonly Dictionary<string, IErrorHandler> _handlers;

        public ErrorHandlers()
        {
            _handlers = new Dictionary<string, IErrorHandler>
            {
                { "NullReferenceException", new NullReferenceExceptionHandler() },
            };
        }

        public IErrorHandler GetHandler(string exType)
        {
            try
            {
                if (!_handlers.ContainsKey(exType))
                {
                    throw new ArgumentException("Invalid command", nameof(exType));
                }
            }
            catch (Exception ex)
            {
                // TODO: Log the exception so the exception type can be added to the dictionary
            }
            return _handlers[exType];
        }
    }
}
