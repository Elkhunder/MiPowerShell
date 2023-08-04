using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Elements
{
    public class PrinterTabElements
    {
        public PrinterTabElements(TableLayoutPanel installedPrinterTable, TableLayoutPanel defaultPrinterTable)
        {
            InstalledPrinterTable = installedPrinterTable;
            DefaultPrinterTable = defaultPrinterTable;
        }

        public TableLayoutPanel InstalledPrinterTable { get; set; }
        public TableLayoutPanel DefaultPrinterTable { get; set; }
    }
}
