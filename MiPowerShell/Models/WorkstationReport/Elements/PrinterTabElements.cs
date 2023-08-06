using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Elements
{
    public class PrinterTabElements
    {
        public PrinterTabElements(DataGridView installedPrintersDataView, TableLayoutPanel defaultPrinterTable)
        {
            InstalledPrintersDataView = installedPrintersDataView;
            DefaultPrinterTable = defaultPrinterTable;
        }

        public DataGridView InstalledPrintersDataView { get; set; }
        public TableLayoutPanel DefaultPrinterTable { get; set; }
    }
}
