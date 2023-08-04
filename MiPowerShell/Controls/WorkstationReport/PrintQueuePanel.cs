using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiPowerShell.Controls.WorkstationReport;

namespace MiPowerShell.Controls.WorkstationReport
{
    public partial class PrintQueuePanel : UserControl
    {
        private PrintQueue? _printQueue;
        private PrinterQueueForm? _printQueueForm;
        public PrinterQueueForm? PrintQueueForm
        {
            get
            {
                return _printQueueForm;
            }
            set
            {
                _printQueueForm = value;
            }
        }
        public PrintQueue? PrintQueue
        {
            get
            {
                return _printQueue;
            }
            set
            {
                _printQueue = value;
            }
        }
        public PrintQueuePanel()
        {
            InitializeComponent();
        }

        public void UpdatePrintJobs(PrintQueue printQueue, PrintJobInfoCollection printJobs)
        {
            // Clear all rows except the header / row 0
            for (int i = printJobTable.RowCount - 1; i > 0; i--)
            {
                for (int j = 0; j < printJobTable.ColumnCount; j++)
                {
                    Control? controlToRemove = printJobTable.GetControlFromPosition(j, i);
                    if (controlToRemove != null)
                    {
                        printJobTable.Controls.Remove(controlToRemove);
                        controlToRemove.Dispose();
                    }
                }

                printJobTable.RowStyles.RemoveAt(i);
            }

            printJobTable.RowCount = 1; // Reset row count

            // Add the print jobs
            AddPrintJobs(printQueue, printJobs);
        }

        public void AddPrintJobs(PrintQueue printQueue, PrintJobInfoCollection printJobs)
        {
            int jobCount = printJobs.Count();
            List<PrintSystemJobInfo> printJobsList = printJobs.Cast<PrintSystemJobInfo>().ToList();

            for (int i = 0; i < jobCount; i++)
            {
                printJobTable.RowCount++;
                printJobTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }
            printJobTable.RowCount++;
            printJobTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

            Console.WriteLine(printJobTable.RowCount);

            for (int i = 1; i <= jobCount; i++)
            {
                PrintSystemJobInfo job = printJobsList[i - 1];
                Label printJobIdentifier = new Label
                {
                    Text = job.JobIdentifier.ToString(),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Tag = job.JobIdentifier,
                };
                Label printJobName = new Label
                {
                    Text = job.JobName,
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Tag = job.JobName,
                };

                Label printJobStatus = new Label
                {
                    Text = job.JobStatus.ToString(),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Tag = job.JobStatus,
                };

                Label printJobPages = new Label
                {
                    Text = $"{job.NumberOfPagesPrinted}/{job.NumberOfPages}",
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Tag = job.NumberOfPages,
                };

                Label printJobSubmitter = new Label
                {
                    Text = job.Submitter,
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Tag = job.Submitter,
                };

                FlowLayoutPanel buttonLayoutPanel = new FlowLayoutPanel()
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.RightToLeft,

                };

                Button printJobCancel = new Button
                {
                    Text = "Cancel",
                    Dock = DockStyle.Fill,
                    Tag = i,
                    AutoSize = false,
                    Height = 45,
                    Width = 85,
                };
                Button printJobRestart = new Button
                {
                    Text = "Restart",
                    Dock = DockStyle.Fill,
                    Tag = i,
                    AutoSize = false,
                    Height = 35,
                    Width = 85,
                };

                printJobCancel.Click += (sender, e) =>
                {
                    job.Cancel();

                    if (_printQueueForm is not null)
                    {
                        PrintQueue printQueue = _printQueueForm.PrintQueue;
                        UpdatePrintJobs(printQueue, printQueue.GetPrintJobInfoCollection());

                        printQueue.Refresh();
                        _printQueueForm.UpdatePrintQueuePanelCards();
                    }
                };
                printJobRestart.Click += (sender, e) =>
                {
                    job.Restart();
                };

                printJobTable.Controls.Add(printJobIdentifier, 0, i);
                printJobTable.Controls.Add(printJobName, 1, i);
                printJobTable.Controls.Add(printJobSubmitter, 2, i);
                printJobTable.Controls.Add(printJobStatus, 3, i);
                printJobTable.Controls.Add(printJobPages, 4, i);
                printJobTable.Controls.Add(printJobRestart, 5, i);
                printJobTable.Controls.Add(printJobCancel, 6, i);
            }
        }
    }
}
