namespace MiPowerShell.Helpers
{
    internal interface IErrorHandler
    {
        void HandleError(Exception ex, string errorSource);
    }
}
