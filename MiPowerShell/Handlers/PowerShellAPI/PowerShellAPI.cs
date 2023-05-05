using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
/*
 * Example
    int maxRunspaces = 10;
    var powerShellAPI = PowerShellAPI.Create(maxRunspaces);

    PSCommand command = new PSCommand();
    command.AddCommand("Get-Process");
    var results = powerShellAPI.RunPowerShell(command);
    powerShellAPI.Dispose();
    foreach ( var result in results)
    {
        Console.WriteLine(result);
    }
 */
namespace MiPowerShell.Handlers
{
    public class PowerShellAPI : IDisposable
    {
        private readonly RunspacePool _runspacePool;
        private bool disposedValue;
        protected PowerShellAPI(RunspacePool runspacePool)
        {
            _runspacePool = runspacePool;
        }
        

        public static PowerShellAPI Create(int maxRunspaces)
        {
            var runspacePool = RunspaceFactory.CreateRunspacePool(minRunspaces: 1, maxRunspaces);
            runspacePool.Open();
            return new PowerShellAPI(runspacePool);
        }
        
        public Collection<PSObject> RunPowerShell(PSCommand command)
        {
            var powershell = PowerShell.Create();
            
            powershell.RunspacePool = _runspacePool;
            powershell.Commands = command;
            var result =  powershell.Invoke();
            return result;
        }

        public Collection<T> RunPowerShell<T>(PSCommand command)
        {
            var powershell = PowerShell.Create();
            
            powershell.RunspacePool = _runspacePool;
            powershell.Commands = command;

            Collection<T> results = powershell.Invoke<T>();
            return results;
        }

        public async Task<Collection<PSObject>> RunPowerShellAsync(PSCommand command)
        {
            var powershell = PowerShell.Create();

            powershell.RunspacePool = _runspacePool;
            powershell.Commands = command;

            PSDataCollection<PSObject> results = await powershell.InvokeAsync().ConfigureAwait(false);
            return new Collection<PSObject>(results);
        }

        public async Task<Collection<T>> RunPowerShellAsync<T>(PSCommand command)
        {
            var powershell = PowerShell.Create();

            powershell.RunspacePool = _runspacePool;
            powershell.Commands = command;

            PSDataCollection<PSObject> results = await powershell.InvokeAsync().ConfigureAwait(false);

            var list = new List<T>(results.Count);
            foreach (PSObject result in results)
            {
                list.Add((T)result.BaseObject);
            }
            return new Collection<T>(list);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if(disposing)
                {
                    _runspacePool.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
