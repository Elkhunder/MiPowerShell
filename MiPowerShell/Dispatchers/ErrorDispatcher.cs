using MiPowerShell.Handlers.Error;

namespace MiPowerShell.Dispatchers
{
    internal class ErrorDispatcher
    {
        private readonly ErrorHandlers? _errorHandlers;

        public ErrorDispatcher()
        {
            _errorHandlers = new ErrorHandlers();
        }

        public void Dispatch(Exception ex, string errorSource="No source provided")
        {
            var handler = _errorHandlers?.GetHandler(ex.GetType().Name);

            handler?.HandleError(ex, errorSource);
        }
    }
}
