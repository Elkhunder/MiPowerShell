using BenchmarkDotNet.Attributes;
using MiPowerShell.Helpers.Managers;

namespace MiPowerShell_Benchmarks.Benchmarks
{
    public class PrinterBenchmark
    {
        public PrinterManager _printManager;

        [Params("Home")]
        public string PrinterName { get; set; }

        [Params("LTRDS011")]
        public string DeviceName { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _printManager = new(DeviceName);
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
        public void GetPrinterNativeTest()
        {
            _printManager.GetPrinterNative(PrinterName);
        }

        [Benchmark]
        public void GetPrinterWmiTest()
        {
            _printManager.GetPrinterWmi(PrinterName);
        }

        [Benchmark]
        public void GetPrinterNamesTest()
        {
            _printManager.GetPrinterNames();
        }

        [Benchmark]
        public void GetPrinterNamesWithDeviceNameTest()
        {
            _printManager.GetPrinterNames(DeviceName);
        }

        [Benchmark]
        public void GetPrinterNamesWmiTest()
        {
            _printManager.GetPrinterNamesWmi();
        }

        

        
    }
}
