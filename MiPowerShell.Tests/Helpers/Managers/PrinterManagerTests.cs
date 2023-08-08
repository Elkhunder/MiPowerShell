using Microsoft.Management.Infrastructure;
using MiPowerShell.Helpers.Managers;
using MiPowerShell.Helpers;
using Moq;
using System.Printing;
using MiPowerShell.Interfaces.Providers;

namespace MiPowerShell.Tests.Helpers.Managers
{
    public class PrinterManagerTests
    {

        [Fact]
        public void GetPrinters_ShouldReturnPrintQueueCollection()
        {
            // Arrange
            var deviceName = "TestDevice";

            var mockPrintServer = new Mock<IPrintServer>();
            var mockCimHandler = new Mock<ICimHandler>();

            mockPrintServer.Setup(p => p.GetPrintQueues()).Returns(new PrintQueueCollection());

            var printerManager = new PrinterManager(deviceName, mockPrintServer.Object, mockCimHandler.Object);

            // Act
            var result = printerManager.GetPrinters();

            // Assert
            Assert.IsType<PrintQueueCollection>(result);
        }

        [Fact]
        public void GetPrintersWmi_ShouldReturnCimInstances()
        {
            // Arrange
            var deviceName = "TestDevice";

            var mockPrintServer = new Mock<IPrintServer>();
            var mockCimHandler = new Mock<ICimHandler>();

            mockCimHandler.Setup(c => c.GetInstances(It.IsAny<string>(), It.IsAny<string>())).Returns(new Microsoft.Management.Infrastructure.CimInstance[0]);

            var printerManager = new PrinterManager(deviceName, mockPrintServer.Object, mockCimHandler.Object);

            // Act
            var result = printerManager.GetPrintersWmi();

            // Assert
            Assert.IsType<Microsoft.Management.Infrastructure.CimInstance[]>(result);
        }

        [Fact]
        public void GetPrinter_ShouldReturnPrintQueue()
        {
            // Arrange
            var deviceName = "TestDevice";
            var existingPrinterName = "ExistingPrinter";

            var mockPrintServer = new Mock<IPrintServer>();
            var mockCimHandler = new Mock<ICimHandler>();

            var mockPrintQueue = new Mock<IPrintQueueWrapper>();
            mockPrintQueue.Setup(pq => pq.Name).Returns(existingPrinterName);

            var mockPrintQueues = new Mock<PrintQueueCollection>();
            mockPrintQueues.Setup(m => m.GetEnumerator()).Returns(
                new List<PrintQueue>
                {
                    new PrintQueue(new LocalPrintServer(), existingPrinterName)
                }.GetEnumerator());

            mockPrintServer.Setup(p => p.GetPrintQueues()).Returns(mockPrintQueues.Object);

            var printerManager = new PrinterManager(deviceName, mockPrintServer.Object, mockCimHandler.Object);

            // Act
            var result = printerManager.GetPrinter(existingPrinterName);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PrintQueue>(result);
            Assert.Equal(existingPrinterName, result.Name);
        }

    }
}
