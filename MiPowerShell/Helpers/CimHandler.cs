using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Management.Infrastructure;
using Microsoft.Management.Infrastructure.Generic;

namespace MiPowerShell.Helpers
{
    public class CimHandler : IDisposable, IObserver<CimInstance>
    {
        private readonly CimSession _cimSession;
        private CimInstance[]? _cimInstances;
        public CimSession CimSession => _cimSession;
        public CimInstance[]? CimInstances => _cimInstances;
        private bool disposedValue;
        private ConcurrentBag<CimInstance> _concurrentBag = new();
        private TaskCompletionSource<IList<CimInstance>> _tcs = new();

        public CimHandler(string termId, string namespaceName, string className)
        {
            _cimSession = CimSession.Create(termId);
            _cimInstances = _cimSession.EnumerateInstances(namespaceName, className).ToArray();
        }
        public CimHandler(string deviceName)
        {
            _cimSession = CimSession.Create(deviceName);
        }
 
        public CimInstance[] GetInstances(string namespaceName, string className)
        {
            return _cimSession.EnumerateInstances(namespaceName, className).ToArray();
        }

        public Task<IList<CimInstance>> GetInstanceAsync(string namespaceName, string className)
        {
            var observable = _cimSession.EnumerateInstancesAsync(namespaceName, className);
            using (observable.Subscribe(this))
            {
                return _tcs.Task;
            }
        }

        public CimInstance[]? GetMonitorInformation()
        {
            string namespaceName = @"root/wmi";
            string className = "WmiMonitorID";

            return _cimSession.EnumerateInstances(namespaceName, className).ToArray();
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

        public void OnCompleted()
        {
            _tcs.SetResult(_concurrentBag.ToList());
        }

        public void OnError(Exception error)
        {
            _tcs.SetException(error);
        }

        public void OnNext(CimInstance value)
        {
            _concurrentBag.Add(value);
        }
    }
}
