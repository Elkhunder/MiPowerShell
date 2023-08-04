using MiPowerShell.Validation;
using System.Net.Http;
using System.Printing;
using System.ServiceProcess;
using System.Web.Services.Description;

namespace MiPowerShell.Controls.WorkstationReport
{
    public partial class PrinterQueueForm : Form
    {
        private UrlValidator _urlValidator = new UrlValidator();
        private UrlSchemeValidator _schemeValidator = new UrlSchemeValidator();
        private PrintQueue _printQueue;
        private ServiceController _serviceController;
        public PrintQueue PrintQueue
        {
            get
            {
                return _printQueue!;
            }
            private set
            {
                _printQueue = value;
            }

        }
        public PrinterQueueForm(PrintQueue printQueue)
        {
            InitializeComponent();
            printQueuePanel.SuspendLayout();
            printQueuePanel.PrintQueueForm = this;
            string deviceName = printQueue.HostingPrintServer.Name.Substring(2);
            _serviceController = new ServiceController("Spooler", deviceName);

            _printQueue = printQueue;
            
            printQueuePanel.AddPrintJobs(printQueue, printQueue.GetPrintJobInfoCollection());
            printQueuePanel.ResumeLayout();

            UpdatePrintQueuePanelCards();
        }

        public void UpdatePrintQueuePanelCards()
        {
            if (_printQueue is not null && _serviceController is not null)
            {
                queueStatusCard.CardValue = _printQueue.QueueStatus.ToString();
                numberOfJobsCard.CardValue = _printQueue.NumberOfJobs.ToString();
                queuePortCard.CardValue = _printQueue.QueuePort.Name;
                spoolStatusCard.CardValue = _serviceController.Status.ToString();
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void refreshPrinterQueues_Click(object sender, EventArgs e)
        {
            _printQueue.Refresh();

            UpdatePrintQueuePanelCards();
            printQueuePanel.UpdatePrintJobs(_printQueue, _printQueue.GetPrintJobInfoCollection());
        }

        private void resumePrinterQueues_Click(object sender, EventArgs e)
        {
            _printQueue.Resume();
            _printQueue.Refresh();

            UpdatePrintQueuePanelCards();
        }

        private void purgePrinterQueues_Click(object sender, EventArgs e)
        {
            _printQueue.Purge();
            _printQueue.Refresh();

            UpdatePrintQueuePanelCards();

            printQueuePanel.UpdatePrintJobs(_printQueue, _printQueue.GetPrintJobInfoCollection());
        }

        private void pausePrinterQueues_Click(object sender, EventArgs e)
        {
            _printQueue.Pause();
            _printQueue.Refresh();

            UpdatePrintQueuePanelCards();
        }

        private void PrinterQueueForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_printQueue is not null)
            {
                _printQueue.Dispose();
            }
        }

        private async void queuePortCard_Click(object sender, EventArgs e)
        {
            string url = $"https://{_printQueue.QueuePort.Name}";
            var psi = new System.Diagnostics.ProcessStartInfo() { UseShellExecute = true };
            FluentValidation.Results.ValidationResult validationResults = _urlValidator.Validate(url);

            if (validationResults.IsValid)
            {
                HttpsTestResult results = await _schemeValidator.IsValidAsync(new FluentValidation.ValidationContext<string>(url), url);

                if (results.IsSuccessCode)
                {
                    psi.FileName = url;
                }
                else if (results.FailureReason is FailureReason.Autentication)
                {
                    psi.FileName = $"http://{_printQueue.QueuePort.Name}";
                }
                else
                {
                    MessageBox.Show(this, results.FailureMessage, "Website Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
            System.Diagnostics.Process.Start(psi);
        }

        private async Task<bool> TestHttpsSupportAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    return response.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        private void restartSpooler_Click(object sender, EventArgs e)
        {
            restartSpooler.Enabled = false;
            try
            {
                TimeSpan timeout = TimeSpan.FromSeconds(10);

                switch (_serviceController?.Status)
                {
                    case ServiceControllerStatus.Running:
                        if (_serviceController.CanStop)
                        {
                            _serviceController.Stop();
                            _serviceController.WaitForStatus(ServiceControllerStatus.Stopped, timeout);



                            if (_serviceController.Status == ServiceControllerStatus.Stopped)
                            {
                                _serviceController.Start();
                                _serviceController.WaitForStatus(ServiceControllerStatus.Running, timeout);

                                restartSpooler.Enabled = true;
                                MessageBox.Show("Spooler service successfully restarted", "Service Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        break;

                    case ServiceControllerStatus.Stopped:
                        _serviceController.Start();
                        _serviceController.WaitForStatus(ServiceControllerStatus.Running, timeout);

                        restartSpooler.Enabled = true;
                        spoolStatusCard.CardValue = _serviceController.Status.ToString();
                        break;

                    case ServiceControllerStatus.StartPending:
                        break;

                    case ServiceControllerStatus.StopPending:
                        break;

                    case ServiceControllerStatus.ContinuePending:
                        break;

                    case ServiceControllerStatus.PausePending:
                        break;

                    case ServiceControllerStatus.Paused:
                        break;

                    default:
                        break;
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.ServiceProcess.TimeoutException ex)
            {
                MessageBox.Show(ex.Message, "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
