using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Elements
{
    public class GeneralTabElements
    {
        public Label OperatingSystemLabel;
        public Label ImageVersionLabel;
        public Label ImageModeLabel;
        public Label CurrentUserLabel;
        public FlowLayoutPanel ScreenPanel;
        public Label ScreenSaverTimeoutLabel;
        public Label ScreenLockTimeoutLabel;
        public Label AutoLogoffTimeoutLabel;
        public FlowLayoutPanel CentricityPanel;
        public Label CentricityTimerLabel;
        public Label CentricityEnvironmentLabel;
        public FlowLayoutPanel BuildPanel;
        public Label BuiltByLabel;
        public Label BuildDateLabel;
    }
}
