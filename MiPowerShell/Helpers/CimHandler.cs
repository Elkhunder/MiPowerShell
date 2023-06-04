using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Management.Infrastructure;

namespace MiPowerShell.Helpers
{
    public class CimHandler : IDisposable
    {
        private readonly CimSession _cimSession;
        private CimInstance[] _cimInstances;
        public CimSession CimSession => _cimSession;
        public CimInstance[] CimInstances => _cimInstances;
        private bool disposedValue;

        public CimHandler(string termId, string namespaceName, string className)
        {
            _cimSession = CimSession.Create(termId);
            _cimInstances = _cimSession.EnumerateInstances(namespaceName, className).ToArray();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _cimSession?.Dispose();
                    for (var i = 0; i < _cimInstances?.Length; i++)
                    {
                        _cimInstances[i].Dispose();
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _cimInstances = null;
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CimHandler()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
