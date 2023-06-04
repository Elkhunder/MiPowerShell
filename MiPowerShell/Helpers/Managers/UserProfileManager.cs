using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Management.Infrastructure;
using Namotion.Reflection;

namespace MiPowerShell.Helpers.Managers
{
    public class UserProfileManager : IDisposable
    {
        private bool disposedValue;
        private readonly string _userName;
        private readonly CimInstance[] _cimInstances;
        private readonly Helpers.CimHandler? _cimHandler;

        public UserProfileManager(string userName, string termId)
        {
            _userName = userName;
            _cimHandler = new Helpers.CimHandler(termId, @"root\CIMv2", "Win32_UserProfile");
            _cimInstances = _cimHandler.CimInstances;
        }

        public CimInstance? GetProfile()
        {
            for (var i = 0; i < _cimInstances?.Length; i++)
            {
                string localPath = (string)_cimInstances[i].CimInstanceProperties["LocalPath"].Value;

                if (localPath.Split('\\')[2] == _userName)
                {
                    return _cimInstances[i];
                }
            }
            return null;
        }

        public int RemoveProfile(CimInstance profile)
        {
            CimSession session = _cimHandler!.CimSession;

            try
            {
                session.DeleteInstance(profile);
                return 0;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    if (_cimHandler != null)
                    {
                        _cimHandler.Dispose();
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UserProfileManager()
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
