using Microsoft.Management.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Interfaces.Providers
{
    public interface ICimHandler : IDisposable
    {
        CimSession CimSession { get; }
        CimInstance[]? CimInstances { get; }

        CimInstance[] GetInstances(string namespaceName, string className);
        Task<IList<CimInstance>> GetInstanceAsync(string namespaceName, string className);
        CimInstance[]? GetMonitorInformation();
    }
}
