using Microsoft.Management.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Helpers
{
    public class CimHandler
    {
        CimSession? _cimSession;
        CimInstance[]? _cimInstances;

        public CimHandler()
        {
        }
        public CimInstance[]? GetInstances(string namespaceName, string className, string termId)
        {
            _cimSession = CimSession.Create(termId);

            if (_cimSession != null && _cimSession.TestConnection())
            {
                try
                {
                    _cimInstances = _cimSession.EnumerateInstances(namespaceName, className).ToArray();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            return _cimInstances;
        }
    }
}
