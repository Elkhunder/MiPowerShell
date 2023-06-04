using Microsoft.CodeAnalysis;
using Microsoft.Management.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Helpers.Managers
{
    public class PrinterManager
    {
        private string? _termId;
        private CimInstance[]? _cimInstances;
        public PrinterManager(string? termId = null)
        {
            _termId = termId;
            
        }

        public PrinterManager(CimInstance[]? cimInstances)
        {
            _cimInstances = cimInstances;
        }

        public string[] GetPrinterList()
        {
            if (_cimInstances == null)
            {
                return new[] { "" };
            }
            string[] printerNames = new string[_cimInstances.Length];

            for (int i = 0; i < printerNames.Length; i++)
            {
                printerNames[i] = (string)_cimInstances[i].CimInstanceProperties["name"].Value;
            }
            return printerNames;
        }

    }
}
