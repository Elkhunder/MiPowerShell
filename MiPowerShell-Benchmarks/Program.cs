using BenchmarkDotNet.Running;
using MiPowerShell.Helpers.Managers;
using MiPowerShell_Benchmarks.Benchmarks;

namespace MiPowerShell_Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PrinterManager printerManager = new("LTRDS011");
            //printerManager.GetPrinterNames("LTRDS011");
            //printerManager.InitializePrintServer();
            var summary = BenchmarkRunner.Run<PrinterBenchmark>();

            Console.ReadLine();
        }
    }
}