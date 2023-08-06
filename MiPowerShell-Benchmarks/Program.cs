using BenchmarkDotNet.Running;
using MiPowerShell_Benchmarks.Benchmarks;

namespace MiPowerShell_Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<PrinterBenchmark>();

            Console.ReadLine();
        }
    }
}