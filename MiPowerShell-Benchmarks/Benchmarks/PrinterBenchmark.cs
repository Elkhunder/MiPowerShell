using BenchmarkDotNet.Attributes;
using MiPowerShell.Helpers.Managers;

namespace MiPowerShell_Benchmarks.Benchmarks
{
    public class PrinterBenchmark
    {
        public PrinterManager _printManager;

        [Params("Home")]
        public string PrinterName { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _printManager = new("LTRDS011");
        }

        [Benchmark]
        public void GetPrinterNamesTest()
        {
            _printManager.GetPrinterNames();
        }

        [Benchmark]
        public void GetPrinterNamesWmiTest()
        {
            _printManager.GetPrinterNamesWmi();
        }

        [Benchmark]
        public void GetPrintersTest()
        {
            _printManager.GetPrinters();
        }

        [Benchmark]
        public void GetPrintersWmiTest()
        {
            _printManager.GetPrintersWmi();
        }

        [Benchmark]
        public void GetPrinterTest()
        {
            _printManager.GetPrinter(PrinterName);
        }

        [Benchmark]
        public void GetPrinterWmiTest()
        {
            _printManager.GetPrinterWmi(PrinterName);
        }
    }
}
