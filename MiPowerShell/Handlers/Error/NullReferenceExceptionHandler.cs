using MiPowerShell.Helpers;

namespace MiPowerShell.Handlers.Error
{
    internal class NullReferenceExceptionHandler : IErrorHandler
    {
        public void HandleError(Exception ex, string name) { }
    }
}
