using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Controls.WorkstationReport
{
    public class OverlayForm : Form
    {
        private Form _activeForm;

        public OverlayForm(Form parent, Form activeForm)
        {
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.Black;
            Opacity = 0.7;
            Bounds = parent.Bounds;
            StartPosition = FormStartPosition.Manual;
            Location = parent.Location;
            TopMost = true;
            ShowInTaskbar = false;
            Click += OverlayForm_Click;

            _activeForm = activeForm;
        }

        private void OverlayForm_Click(object? sender, EventArgs e)
        {
            if (_activeForm is not null && _activeForm.Visible is true)
            {
                _activeForm.Close();

                if (_activeForm.IsDisposed is not true)
                {
                    _activeForm.Dispose();
                }
            }

        }
    }
}
