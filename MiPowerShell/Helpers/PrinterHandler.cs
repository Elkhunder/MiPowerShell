﻿using Microsoft.CodeAnalysis;
using Microsoft.Management.Infrastructure;

namespace MiPowerShell.Helpers
{
    public class PrinterHandler : IDisposable
    {
        private bool disposedValue;

        public PrinterHandler(string computerName)
        {
        }

        public static Optional<string[]> GetPrinterList(string computerName)
        {
            string namespaceName = @"root\cimv2";
            string className = "CIM_Printer";

            CimHandler cimHandler = new(computerName, namespaceName, className);
            CimInstance[] cimInstance = cimHandler.CimInstances;
            string[]? printerNames = null;
            bool isOnline = DeviceStatusChecked.IsDeviceOnline(computerName);
            if (isOnline)
            {
                if (cimInstance != null)
                {
                    printerNames = new string[cimInstance.Length];
                    for (int i = 0; i < cimInstance.Length; i++)
                    {
                        printerNames[i] = (string)cimInstance[i].CimInstanceProperties["name"].Value;
                    }
                    cimHandler?.Dispose();
                    return printerNames;
                }
            }
            return new[] {""};
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~PrinterHandler()
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
