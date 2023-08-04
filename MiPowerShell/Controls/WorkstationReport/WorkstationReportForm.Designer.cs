using MiPowerShell.Handlers.Events;

namespace MiPowerShell.Controls
{
    partial class WorkstationReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkstationReportForm));
            headingFlowLayoutPanel = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            workstationReportHeadingLabel = new Label();
            loadingLabel = new Label();
            mainTableLayoutPanel = new TableLayoutPanel();
            headerFlowLayoutPanel = new FlowLayoutPanel();
            deviceNameHeaderLabel = new Label();
            ipAddressHeaderLabel = new Label();
            imageVersionHeaderLabel = new Label();
            imageModeHeaderLabel = new Label();
            currentUserHeaderLabel = new Label();
            navigationFlowLayoutPanel = new FlowLayoutPanel();
            generalNavButton = new Button();
            maintenanceNavButton = new Button();
            hardwareNavButton = new Button();
            biosNavButton = new Button();
            networkNavButton = new Button();
            printersNavButton = new Button();
            securityNavButton = new Button();
            softwareNavButton = new Button();
            pictureBox2 = new PictureBox();
            mainTabControl = new TabControl();
            generalTabPage = new TabPage();
            generalTableLayoutPanel = new TableLayoutPanel();
            generalInformationFlowLayoutPanel = new FlowLayoutPanel();
            generalInformationHeaderLabel = new Label();
            operatingSystemLabel = new Label();
            imageVersionLabel = new Label();
            imageModeLabel = new Label();
            currentUserLabel = new Label();
            screenTimeoutFlowLayoutPanel = new FlowLayoutPanel();
            screenTimeoutHeaderLabel = new Label();
            screenSaverTimeoutLabel = new Label();
            screenLockTimeoutLabel = new Label();
            autoLogoffTimeoutLabel = new Label();
            centricityFlowLayoutPanel = new FlowLayoutPanel();
            centricityHeaderLabel = new Label();
            centricityTimerLabel = new Label();
            centricityEnvironmentLabel = new Label();
            buildInformationFlowLayoutPanel = new FlowLayoutPanel();
            buildInformationHeaderLabel = new Label();
            builtByLabel = new Label();
            buildDateLabel = new Label();
            maintenanceTabPage = new TabPage();
            maintenanceTableLayoutPanel = new TableLayoutPanel();
            maintenanceConfigurationFlowLayoutPanel = new FlowLayoutPanel();
            maintenanceConfigurationLabel = new Label();
            maintenanceTimeLabel = new Label();
            lastBeganLabel = new Label();
            lastCompletedLabel = new Label();
            lastSucceededLabel = new Label();
            lastResultLabel = new Label();
            rebootPendingLabel = new Label();
            machineUpTimeLabel = new Label();
            powerManagementFlowLayoutPanel = new FlowLayoutPanel();
            powerManagementHeaderLabel = new Label();
            systemUnitManagementLabel = new Label();
            hardwareTabPage = new TabPage();
            hardwareTableLayoutPanel = new TableLayoutPanel();
            videoControllersHeaderLabel = new Label();
            logicalDisksHeaderLabel = new Label();
            physicalDisksHeaderLabel = new Label();
            hardwareProcessorsTable = new TableLayoutPanel();
            processorNameHeadingLabel = new Label();
            processorTypeHeadingLabel = new Label();
            architectureHeadingLabel = new Label();
            cpuStatusHeadingLabel = new Label();
            systemInformationPanel = new FlowLayoutPanel();
            systemInformationHeaderLabel = new Label();
            modelLabel = new Label();
            manufacturerLabel = new Label();
            SMBIOSAssetTagLabel = new Label();
            serialNumberLabel = new Label();
            hardwareMemoryTable = new TableLayoutPanel();
            memoryNameHeadingLabel = new Label();
            memoryCapacityLabel = new Label();
            memorySpeedLabel = new Label();
            memoryTypeLabel = new Label();
            hardwarePhysicalDisksTable = new TableLayoutPanel();
            hardDriveNameHeadingLabel = new Label();
            hardDriveModelHeadingLabel = new Label();
            hardDriveSizeHeadingLabel = new Label();
            hardDriveTypeHeadingLabel = new Label();
            hardDrivePartitionsHeadingLabel = new Label();
            memoryHeaderLabel = new Label();
            hardwareLogicalDisksTable = new TableLayoutPanel();
            diskDriveIdHeadingLabel = new Label();
            diskDriveNameHeadingLabel = new Label();
            diskDriveFileSystemHeadingLabel = new Label();
            diskDriveDriveTypeHeadingLabel = new Label();
            diskDriveMediaTypeHeadingLabel = new Label();
            diskDriveFreeSpaceHeadingLabel = new Label();
            diskDriveCapacityHeadingLabel = new Label();
            processorsHeaderLabel = new Label();
            hardwareVideoContollersTable = new TableLayoutPanel();
            videoControllerNameHeadingLabel = new Label();
            videoControllerRamHeadingLabel = new Label();
            videoControllerBitsPerPixelHeadingLabel = new Label();
            videoControllerDriverVersionHeadingLabel = new Label();
            videoControllerDriverDateHeadingLabel = new Label();
            videoControllerVideoProcessorHeadingLabel = new Label();
            biosTabPage = new TabPage();
            biosTable = new TableLayoutPanel();
            biosInformationHeader = new Label();
            biosInformationPanel = new FlowLayoutPanel();
            bootOrderHeader = new Label();
            bootOrderPanel = new FlowLayoutPanel();
            biosSettingsHeader = new Label();
            biosSettingsTable = new TableLayoutPanel();
            biosAttributeName = new Label();
            biosCurrentValue = new Label();
            biosPossibleValues = new Label();
            networkTabPage = new TabPage();
            networkTable = new TableLayoutPanel();
            networkAdaptersHeader = new Label();
            ipConfigurationHeader = new Label();
            networkAdaptersTable = new TableLayoutPanel();
            ipConfigurationTable = new TableLayoutPanel();
            printersTabPage = new TabPage();
            printerTable = new TableLayoutPanel();
            installedPrintersHeader = new Label();
            printerDeafultHeader = new Label();
            installedPrinterTable = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            defaultPrinterTable = new TableLayoutPanel();
            label4 = new Label();
            label5 = new Label();
            securityTabPage = new TabPage();
            securityTable = new TableLayoutPanel();
            localAccountsTable = new TableLayoutPanel();
            localAdministratorsTable = new TableLayoutPanel();
            localAccountsHeader = new Label();
            localAdministratorsHeader = new Label();
            installedHotFixesHeader = new Label();
            firewallRulesHeader = new Label();
            installedHotFixesTable = new TableLayoutPanel();
            firewallRulesTable = new TableLayoutPanel();
            softwareTabPage = new TabPage();
            softwareDataView = new DataGridView();
            exitButton = new Button();
            installedSoftwareBindingSource = new BindingSource(components);
            softwareInformationBindingSource = new BindingSource(components);
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            headingFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            mainTableLayoutPanel.SuspendLayout();
            headerFlowLayoutPanel.SuspendLayout();
            navigationFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            mainTabControl.SuspendLayout();
            generalTabPage.SuspendLayout();
            generalTableLayoutPanel.SuspendLayout();
            generalInformationFlowLayoutPanel.SuspendLayout();
            screenTimeoutFlowLayoutPanel.SuspendLayout();
            centricityFlowLayoutPanel.SuspendLayout();
            buildInformationFlowLayoutPanel.SuspendLayout();
            maintenanceTabPage.SuspendLayout();
            maintenanceTableLayoutPanel.SuspendLayout();
            maintenanceConfigurationFlowLayoutPanel.SuspendLayout();
            powerManagementFlowLayoutPanel.SuspendLayout();
            hardwareTabPage.SuspendLayout();
            hardwareTableLayoutPanel.SuspendLayout();
            hardwareProcessorsTable.SuspendLayout();
            systemInformationPanel.SuspendLayout();
            hardwareMemoryTable.SuspendLayout();
            hardwarePhysicalDisksTable.SuspendLayout();
            hardwareLogicalDisksTable.SuspendLayout();
            hardwareVideoContollersTable.SuspendLayout();
            biosTabPage.SuspendLayout();
            biosTable.SuspendLayout();
            biosSettingsTable.SuspendLayout();
            networkTabPage.SuspendLayout();
            networkTable.SuspendLayout();
            printersTabPage.SuspendLayout();
            printerTable.SuspendLayout();
            installedPrinterTable.SuspendLayout();
            defaultPrinterTable.SuspendLayout();
            securityTabPage.SuspendLayout();
            securityTable.SuspendLayout();
            softwareTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)softwareDataView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)installedSoftwareBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)softwareInformationBindingSource).BeginInit();
            SuspendLayout();
            // 
            // headingFlowLayoutPanel
            // 
            headingFlowLayoutPanel.AutoSize = true;
            headingFlowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            headingFlowLayoutPanel.Controls.Add(pictureBox1);
            headingFlowLayoutPanel.Controls.Add(workstationReportHeadingLabel);
            headingFlowLayoutPanel.Controls.Add(loadingLabel);
            headingFlowLayoutPanel.Dock = DockStyle.Top;
            headingFlowLayoutPanel.Location = new Point(0, 0);
            headingFlowLayoutPanel.Name = "headingFlowLayoutPanel";
            headingFlowLayoutPanel.Padding = new Padding(10, 5, 0, 0);
            headingFlowLayoutPanel.Size = new Size(1637, 43);
            headingFlowLayoutPanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Bottom;
            pictureBox1.Image = Properties.Resources.Michigan;
            pictureBox1.Location = new Point(13, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // workstationReportHeadingLabel
            // 
            workstationReportHeadingLabel.AutoSize = true;
            workstationReportHeadingLabel.Dock = DockStyle.Fill;
            workstationReportHeadingLabel.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            workstationReportHeadingLabel.Location = new Point(51, 5);
            workstationReportHeadingLabel.Name = "workstationReportHeadingLabel";
            workstationReportHeadingLabel.Size = new Size(172, 38);
            workstationReportHeadingLabel.TabIndex = 1;
            workstationReportHeadingLabel.Text = "Workstation Report";
            workstationReportHeadingLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // loadingLabel
            // 
            loadingLabel.AutoSize = true;
            loadingLabel.BackColor = Color.Transparent;
            loadingLabel.Dock = DockStyle.Fill;
            loadingLabel.Location = new Point(626, 8);
            loadingLabel.Margin = new Padding(400, 3, 3, 3);
            loadingLabel.Name = "loadingLabel";
            loadingLabel.Size = new Size(96, 32);
            loadingLabel.TabIndex = 2;
            loadingLabel.Text = "Loading ...";
            loadingLabel.TextAlign = ContentAlignment.MiddleCenter;
            loadingLabel.Visible = false;
            // 
            // mainTableLayoutPanel
            // 
            mainTableLayoutPanel.AutoSize = true;
            mainTableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainTableLayoutPanel.ColumnCount = 2;
            mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.5690794F));
            mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 86.43092F));
            mainTableLayoutPanel.Controls.Add(headerFlowLayoutPanel, 0, 0);
            mainTableLayoutPanel.Controls.Add(navigationFlowLayoutPanel, 0, 1);
            mainTableLayoutPanel.Controls.Add(mainTabControl, 1, 1);
            mainTableLayoutPanel.Controls.Add(exitButton, 1, 2);
            mainTableLayoutPanel.Dock = DockStyle.Fill;
            mainTableLayoutPanel.Location = new Point(0, 43);
            mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            mainTableLayoutPanel.RowCount = 3;
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 607F));
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            mainTableLayoutPanel.Size = new Size(1637, 705);
            mainTableLayoutPanel.TabIndex = 1;
            // 
            // headerFlowLayoutPanel
            // 
            headerFlowLayoutPanel.AutoSize = true;
            headerFlowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainTableLayoutPanel.SetColumnSpan(headerFlowLayoutPanel, 2);
            headerFlowLayoutPanel.Controls.Add(deviceNameHeaderLabel);
            headerFlowLayoutPanel.Controls.Add(ipAddressHeaderLabel);
            headerFlowLayoutPanel.Controls.Add(imageVersionHeaderLabel);
            headerFlowLayoutPanel.Controls.Add(imageModeHeaderLabel);
            headerFlowLayoutPanel.Controls.Add(currentUserHeaderLabel);
            headerFlowLayoutPanel.Dock = DockStyle.Fill;
            headerFlowLayoutPanel.Location = new Point(3, 3);
            headerFlowLayoutPanel.Name = "headerFlowLayoutPanel";
            headerFlowLayoutPanel.Padding = new Padding(10, 0, 0, 0);
            headerFlowLayoutPanel.Size = new Size(1631, 29);
            headerFlowLayoutPanel.TabIndex = 0;
            // 
            // deviceNameHeaderLabel
            // 
            deviceNameHeaderLabel.AutoSize = true;
            deviceNameHeaderLabel.Dock = DockStyle.Left;
            deviceNameHeaderLabel.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point);
            deviceNameHeaderLabel.Location = new Point(13, 5);
            deviceNameHeaderLabel.Margin = new Padding(3, 5, 3, 0);
            deviceNameHeaderLabel.Name = "deviceNameHeaderLabel";
            deviceNameHeaderLabel.Size = new Size(63, 16);
            deviceNameHeaderLabel.TabIndex = 6;
            deviceNameHeaderLabel.Text = "LTRDS011";
            // 
            // ipAddressHeaderLabel
            // 
            ipAddressHeaderLabel.AutoSize = true;
            ipAddressHeaderLabel.Dock = DockStyle.Left;
            ipAddressHeaderLabel.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ipAddressHeaderLabel.Location = new Point(82, 5);
            ipAddressHeaderLabel.Margin = new Padding(3, 5, 3, 0);
            ipAddressHeaderLabel.Name = "ipAddressHeaderLabel";
            ipAddressHeaderLabel.Size = new Size(56, 16);
            ipAddressHeaderLabel.TabIndex = 0;
            ipAddressHeaderLabel.Text = "0.0.0.0";
            ipAddressHeaderLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // imageVersionHeaderLabel
            // 
            imageVersionHeaderLabel.AutoSize = true;
            imageVersionHeaderLabel.Dock = DockStyle.Left;
            imageVersionHeaderLabel.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point);
            imageVersionHeaderLabel.Location = new Point(144, 5);
            imageVersionHeaderLabel.Margin = new Padding(3, 5, 3, 0);
            imageVersionHeaderLabel.Name = "imageVersionHeaderLabel";
            imageVersionHeaderLabel.Size = new Size(35, 16);
            imageVersionHeaderLabel.TabIndex = 1;
            imageVersionHeaderLabel.Text = "21H2";
            imageVersionHeaderLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // imageModeHeaderLabel
            // 
            imageModeHeaderLabel.AutoSize = true;
            imageModeHeaderLabel.Dock = DockStyle.Left;
            imageModeHeaderLabel.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point);
            imageModeHeaderLabel.Location = new Point(185, 5);
            imageModeHeaderLabel.Margin = new Padding(3, 5, 3, 0);
            imageModeHeaderLabel.Name = "imageModeHeaderLabel";
            imageModeHeaderLabel.Size = new Size(63, 16);
            imageModeHeaderLabel.TabIndex = 2;
            imageModeHeaderLabel.Text = "Standard";
            imageModeHeaderLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // currentUserHeaderLabel
            // 
            currentUserHeaderLabel.AutoSize = true;
            currentUserHeaderLabel.Dock = DockStyle.Left;
            currentUserHeaderLabel.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point);
            currentUserHeaderLabel.Location = new Point(254, 5);
            currentUserHeaderLabel.Margin = new Padding(3, 5, 3, 0);
            currentUserHeaderLabel.Name = "currentUserHeaderLabel";
            currentUserHeaderLabel.Size = new Size(91, 16);
            currentUserHeaderLabel.TabIndex = 3;
            currentUserHeaderLabel.Text = "UMHS\\jsissom";
            currentUserHeaderLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // navigationFlowLayoutPanel
            // 
            navigationFlowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            navigationFlowLayoutPanel.BackColor = SystemColors.Control;
            navigationFlowLayoutPanel.Controls.Add(generalNavButton);
            navigationFlowLayoutPanel.Controls.Add(maintenanceNavButton);
            navigationFlowLayoutPanel.Controls.Add(hardwareNavButton);
            navigationFlowLayoutPanel.Controls.Add(biosNavButton);
            navigationFlowLayoutPanel.Controls.Add(networkNavButton);
            navigationFlowLayoutPanel.Controls.Add(printersNavButton);
            navigationFlowLayoutPanel.Controls.Add(securityNavButton);
            navigationFlowLayoutPanel.Controls.Add(softwareNavButton);
            navigationFlowLayoutPanel.Controls.Add(pictureBox2);
            navigationFlowLayoutPanel.Dock = DockStyle.Fill;
            navigationFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            navigationFlowLayoutPanel.Location = new Point(10, 38);
            navigationFlowLayoutPanel.Margin = new Padding(10, 3, 3, 3);
            navigationFlowLayoutPanel.Name = "navigationFlowLayoutPanel";
            navigationFlowLayoutPanel.Padding = new Padding(0, 40, 0, 0);
            mainTableLayoutPanel.SetRowSpan(navigationFlowLayoutPanel, 2);
            navigationFlowLayoutPanel.Size = new Size(209, 664);
            navigationFlowLayoutPanel.TabIndex = 2;
            // 
            // generalNavButton
            // 
            generalNavButton.Dock = DockStyle.Left;
            generalNavButton.Location = new Point(3, 43);
            generalNavButton.Name = "generalNavButton";
            generalNavButton.Size = new Size(144, 35);
            generalNavButton.TabIndex = 0;
            generalNavButton.Text = "General";
            generalNavButton.UseVisualStyleBackColor = true;
            generalNavButton.Click += generalNavButton_Click;
            // 
            // maintenanceNavButton
            // 
            maintenanceNavButton.Location = new Point(3, 84);
            maintenanceNavButton.Name = "maintenanceNavButton";
            maintenanceNavButton.Size = new Size(144, 35);
            maintenanceNavButton.TabIndex = 1;
            maintenanceNavButton.Text = "Maintenance";
            maintenanceNavButton.UseVisualStyleBackColor = true;
            maintenanceNavButton.Click += maintenanceNavButton_Click;
            // 
            // hardwareNavButton
            // 
            hardwareNavButton.Location = new Point(3, 125);
            hardwareNavButton.Name = "hardwareNavButton";
            hardwareNavButton.Size = new Size(144, 35);
            hardwareNavButton.TabIndex = 2;
            hardwareNavButton.Text = "Hardware";
            hardwareNavButton.UseVisualStyleBackColor = true;
            hardwareNavButton.Click += hardwareNavButton_Click;
            // 
            // biosNavButton
            // 
            biosNavButton.Location = new Point(3, 166);
            biosNavButton.Name = "biosNavButton";
            biosNavButton.Size = new Size(144, 35);
            biosNavButton.TabIndex = 3;
            biosNavButton.Text = "BIOS";
            biosNavButton.UseVisualStyleBackColor = true;
            biosNavButton.Click += biosNavButton_Click;
            // 
            // networkNavButton
            // 
            networkNavButton.Location = new Point(3, 207);
            networkNavButton.Name = "networkNavButton";
            networkNavButton.Size = new Size(144, 35);
            networkNavButton.TabIndex = 4;
            networkNavButton.Text = "Network";
            networkNavButton.UseVisualStyleBackColor = true;
            networkNavButton.Click += networkNavButton_Click;
            // 
            // printersNavButton
            // 
            printersNavButton.Location = new Point(3, 248);
            printersNavButton.Name = "printersNavButton";
            printersNavButton.Size = new Size(144, 35);
            printersNavButton.TabIndex = 5;
            printersNavButton.Text = "Printers";
            printersNavButton.UseVisualStyleBackColor = true;
            printersNavButton.Click += printersNavButton_Click;
            // 
            // securityNavButton
            // 
            securityNavButton.Location = new Point(3, 289);
            securityNavButton.Name = "securityNavButton";
            securityNavButton.Size = new Size(144, 35);
            securityNavButton.TabIndex = 6;
            securityNavButton.Text = "Security";
            securityNavButton.UseVisualStyleBackColor = true;
            securityNavButton.Click += securityNavButton_Click;
            // 
            // softwareNavButton
            // 
            softwareNavButton.Location = new Point(3, 330);
            softwareNavButton.Name = "softwareNavButton";
            softwareNavButton.Size = new Size(144, 35);
            softwareNavButton.TabIndex = 7;
            softwareNavButton.Text = "Software";
            softwareNavButton.UseVisualStyleBackColor = true;
            softwareNavButton.Click += softwareNavButton_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Image = Properties.Resources.Michigan_Medicine_Logo_Stacked_CMYK;
            pictureBox2.Location = new Point(3, 543);
            pictureBox2.Margin = new Padding(3, 175, 3, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(144, 103);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // mainTabControl
            // 
            mainTabControl.Controls.Add(generalTabPage);
            mainTabControl.Controls.Add(maintenanceTabPage);
            mainTabControl.Controls.Add(hardwareTabPage);
            mainTabControl.Controls.Add(biosTabPage);
            mainTabControl.Controls.Add(networkTabPage);
            mainTabControl.Controls.Add(printersTabPage);
            mainTabControl.Controls.Add(securityTabPage);
            mainTabControl.Controls.Add(softwareTabPage);
            mainTabControl.Dock = DockStyle.Fill;
            mainTabControl.Location = new Point(225, 38);
            mainTabControl.Margin = new Padding(3, 3, 10, 3);
            mainTabControl.Name = "mainTabControl";
            mainTabControl.SelectedIndex = 0;
            mainTabControl.Size = new Size(1402, 601);
            mainTabControl.TabIndex = 4;
            mainTabControl.MouseClick += mainTabControl_MouseClick;
            // 
            // generalTabPage
            // 
            generalTabPage.Controls.Add(generalTableLayoutPanel);
            generalTabPage.Location = new Point(4, 26);
            generalTabPage.Name = "generalTabPage";
            generalTabPage.Padding = new Padding(3);
            generalTabPage.Size = new Size(1394, 571);
            generalTabPage.TabIndex = 0;
            generalTabPage.Text = "General";
            generalTabPage.UseVisualStyleBackColor = true;
            // 
            // generalTableLayoutPanel
            // 
            generalTableLayoutPanel.AutoSize = true;
            generalTableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            generalTableLayoutPanel.ColumnCount = 1;
            generalTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            generalTableLayoutPanel.Controls.Add(generalInformationFlowLayoutPanel, 0, 0);
            generalTableLayoutPanel.Controls.Add(screenTimeoutFlowLayoutPanel, 0, 1);
            generalTableLayoutPanel.Controls.Add(centricityFlowLayoutPanel, 0, 2);
            generalTableLayoutPanel.Controls.Add(buildInformationFlowLayoutPanel, 0, 3);
            generalTableLayoutPanel.Dock = DockStyle.Fill;
            generalTableLayoutPanel.Location = new Point(3, 3);
            generalTableLayoutPanel.Name = "generalTableLayoutPanel";
            generalTableLayoutPanel.RowCount = 4;
            generalTableLayoutPanel.RowStyles.Add(new RowStyle());
            generalTableLayoutPanel.RowStyles.Add(new RowStyle());
            generalTableLayoutPanel.RowStyles.Add(new RowStyle());
            generalTableLayoutPanel.RowStyles.Add(new RowStyle());
            generalTableLayoutPanel.Size = new Size(1388, 565);
            generalTableLayoutPanel.TabIndex = 0;
            // 
            // generalInformationFlowLayoutPanel
            // 
            generalInformationFlowLayoutPanel.AutoSize = true;
            generalInformationFlowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            generalInformationFlowLayoutPanel.Controls.Add(generalInformationHeaderLabel);
            generalInformationFlowLayoutPanel.Controls.Add(operatingSystemLabel);
            generalInformationFlowLayoutPanel.Controls.Add(imageVersionLabel);
            generalInformationFlowLayoutPanel.Controls.Add(imageModeLabel);
            generalInformationFlowLayoutPanel.Controls.Add(currentUserLabel);
            generalInformationFlowLayoutPanel.Dock = DockStyle.Fill;
            generalInformationFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            generalInformationFlowLayoutPanel.Location = new Point(3, 3);
            generalInformationFlowLayoutPanel.Name = "generalInformationFlowLayoutPanel";
            generalInformationFlowLayoutPanel.Size = new Size(1382, 104);
            generalInformationFlowLayoutPanel.TabIndex = 0;
            // 
            // generalInformationHeaderLabel
            // 
            generalInformationHeaderLabel.AutoSize = true;
            generalInformationHeaderLabel.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            generalInformationHeaderLabel.Location = new Point(3, 2);
            generalInformationHeaderLabel.Margin = new Padding(3, 2, 3, 0);
            generalInformationHeaderLabel.Name = "generalInformationHeaderLabel";
            generalInformationHeaderLabel.Size = new Size(160, 17);
            generalInformationHeaderLabel.TabIndex = 0;
            generalInformationHeaderLabel.Text = "General Information";
            // 
            // operatingSystemLabel
            // 
            operatingSystemLabel.AutoSize = true;
            operatingSystemLabel.Location = new Point(3, 27);
            operatingSystemLabel.Margin = new Padding(3, 8, 3, 0);
            operatingSystemLabel.Name = "operatingSystemLabel";
            operatingSystemLabel.Size = new Size(320, 17);
            operatingSystemLabel.TabIndex = 1;
            operatingSystemLabel.Text = "Operating System:  Microsoft Windows 10";
            // 
            // imageVersionLabel
            // 
            imageVersionLabel.AutoSize = true;
            imageVersionLabel.Location = new Point(3, 47);
            imageVersionLabel.Margin = new Padding(3, 3, 3, 0);
            imageVersionLabel.Name = "imageVersionLabel";
            imageVersionLabel.Size = new Size(168, 17);
            imageVersionLabel.TabIndex = 2;
            imageVersionLabel.Text = "Image Version:  21H2";
            // 
            // imageModeLabel
            // 
            imageModeLabel.AutoSize = true;
            imageModeLabel.Location = new Point(3, 67);
            imageModeLabel.Margin = new Padding(3, 3, 3, 0);
            imageModeLabel.Name = "imageModeLabel";
            imageModeLabel.Size = new Size(128, 17);
            imageModeLabel.TabIndex = 3;
            imageModeLabel.Text = "Mode:  Standard";
            // 
            // currentUserLabel
            // 
            currentUserLabel.AutoSize = true;
            currentUserLabel.Location = new Point(3, 87);
            currentUserLabel.Margin = new Padding(3, 3, 3, 0);
            currentUserLabel.Name = "currentUserLabel";
            currentUserLabel.Size = new Size(224, 17);
            currentUserLabel.TabIndex = 4;
            currentUserLabel.Text = "Current User:  UMHS\\jsissom";
            // 
            // screenTimeoutFlowLayoutPanel
            // 
            screenTimeoutFlowLayoutPanel.AutoSize = true;
            screenTimeoutFlowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            screenTimeoutFlowLayoutPanel.Controls.Add(screenTimeoutHeaderLabel);
            screenTimeoutFlowLayoutPanel.Controls.Add(screenSaverTimeoutLabel);
            screenTimeoutFlowLayoutPanel.Controls.Add(screenLockTimeoutLabel);
            screenTimeoutFlowLayoutPanel.Controls.Add(autoLogoffTimeoutLabel);
            screenTimeoutFlowLayoutPanel.Dock = DockStyle.Fill;
            screenTimeoutFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            screenTimeoutFlowLayoutPanel.Location = new Point(3, 113);
            screenTimeoutFlowLayoutPanel.Name = "screenTimeoutFlowLayoutPanel";
            screenTimeoutFlowLayoutPanel.Size = new Size(1382, 84);
            screenTimeoutFlowLayoutPanel.TabIndex = 1;
            // 
            // screenTimeoutHeaderLabel
            // 
            screenTimeoutHeaderLabel.AutoSize = true;
            screenTimeoutHeaderLabel.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            screenTimeoutHeaderLabel.Location = new Point(3, 2);
            screenTimeoutHeaderLabel.Margin = new Padding(3, 2, 3, 0);
            screenTimeoutHeaderLabel.Name = "screenTimeoutHeaderLabel";
            screenTimeoutHeaderLabel.Size = new Size(128, 17);
            screenTimeoutHeaderLabel.TabIndex = 0;
            screenTimeoutHeaderLabel.Text = "Screen Timeouts";
            // 
            // screenSaverTimeoutLabel
            // 
            screenSaverTimeoutLabel.AutoSize = true;
            screenSaverTimeoutLabel.Location = new Point(3, 27);
            screenSaverTimeoutLabel.Margin = new Padding(3, 8, 3, 0);
            screenSaverTimeoutLabel.Name = "screenSaverTimeoutLabel";
            screenSaverTimeoutLabel.Size = new Size(256, 17);
            screenSaverTimeoutLabel.TabIndex = 1;
            screenSaverTimeoutLabel.Text = "Screen Saver Timeout:  00:30:00";
            // 
            // screenLockTimeoutLabel
            // 
            screenLockTimeoutLabel.AutoSize = true;
            screenLockTimeoutLabel.Location = new Point(3, 47);
            screenLockTimeoutLabel.Margin = new Padding(3, 3, 3, 0);
            screenLockTimeoutLabel.Name = "screenLockTimeoutLabel";
            screenLockTimeoutLabel.Size = new Size(248, 17);
            screenLockTimeoutLabel.TabIndex = 2;
            screenLockTimeoutLabel.Text = "Screen Lock Timeout:  00:31:00";
            // 
            // autoLogoffTimeoutLabel
            // 
            autoLogoffTimeoutLabel.AutoSize = true;
            autoLogoffTimeoutLabel.Location = new Point(3, 67);
            autoLogoffTimeoutLabel.Margin = new Padding(3, 3, 3, 0);
            autoLogoffTimeoutLabel.Name = "autoLogoffTimeoutLabel";
            autoLogoffTimeoutLabel.Size = new Size(256, 17);
            autoLogoffTimeoutLabel.TabIndex = 3;
            autoLogoffTimeoutLabel.Text = "Auto Logoff Timeout:  Not Found";
            // 
            // centricityFlowLayoutPanel
            // 
            centricityFlowLayoutPanel.AutoSize = true;
            centricityFlowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            centricityFlowLayoutPanel.Controls.Add(centricityHeaderLabel);
            centricityFlowLayoutPanel.Controls.Add(centricityTimerLabel);
            centricityFlowLayoutPanel.Controls.Add(centricityEnvironmentLabel);
            centricityFlowLayoutPanel.Dock = DockStyle.Fill;
            centricityFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            centricityFlowLayoutPanel.Location = new Point(3, 203);
            centricityFlowLayoutPanel.Name = "centricityFlowLayoutPanel";
            centricityFlowLayoutPanel.Size = new Size(1382, 64);
            centricityFlowLayoutPanel.TabIndex = 2;
            // 
            // centricityHeaderLabel
            // 
            centricityHeaderLabel.AutoSize = true;
            centricityHeaderLabel.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            centricityHeaderLabel.Location = new Point(3, 2);
            centricityHeaderLabel.Margin = new Padding(3, 2, 3, 0);
            centricityHeaderLabel.Name = "centricityHeaderLabel";
            centricityHeaderLabel.Size = new Size(88, 17);
            centricityHeaderLabel.TabIndex = 0;
            centricityHeaderLabel.Text = "Centricity";
            // 
            // centricityTimerLabel
            // 
            centricityTimerLabel.AutoSize = true;
            centricityTimerLabel.Location = new Point(3, 27);
            centricityTimerLabel.Margin = new Padding(3, 8, 3, 0);
            centricityTimerLabel.Name = "centricityTimerLabel";
            centricityTimerLabel.Size = new Size(96, 17);
            centricityTimerLabel.TabIndex = 1;
            centricityTimerLabel.Text = "Timer:  719";
            // 
            // centricityEnvironmentLabel
            // 
            centricityEnvironmentLabel.AutoSize = true;
            centricityEnvironmentLabel.Location = new Point(3, 47);
            centricityEnvironmentLabel.Margin = new Padding(3, 3, 3, 0);
            centricityEnvironmentLabel.Name = "centricityEnvironmentLabel";
            centricityEnvironmentLabel.Size = new Size(152, 17);
            centricityEnvironmentLabel.TabIndex = 2;
            centricityEnvironmentLabel.Text = "Environment:  Prod";
            // 
            // buildInformationFlowLayoutPanel
            // 
            buildInformationFlowLayoutPanel.AutoSize = true;
            buildInformationFlowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buildInformationFlowLayoutPanel.Controls.Add(buildInformationHeaderLabel);
            buildInformationFlowLayoutPanel.Controls.Add(builtByLabel);
            buildInformationFlowLayoutPanel.Controls.Add(buildDateLabel);
            buildInformationFlowLayoutPanel.Dock = DockStyle.Fill;
            buildInformationFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            buildInformationFlowLayoutPanel.Location = new Point(3, 273);
            buildInformationFlowLayoutPanel.Name = "buildInformationFlowLayoutPanel";
            buildInformationFlowLayoutPanel.Size = new Size(1382, 289);
            buildInformationFlowLayoutPanel.TabIndex = 3;
            // 
            // buildInformationHeaderLabel
            // 
            buildInformationHeaderLabel.AutoSize = true;
            buildInformationHeaderLabel.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buildInformationHeaderLabel.Location = new Point(3, 2);
            buildInformationHeaderLabel.Margin = new Padding(3, 2, 3, 0);
            buildInformationHeaderLabel.Name = "buildInformationHeaderLabel";
            buildInformationHeaderLabel.Size = new Size(144, 17);
            buildInformationHeaderLabel.TabIndex = 0;
            buildInformationHeaderLabel.Text = "Build Information";
            // 
            // builtByLabel
            // 
            builtByLabel.AutoSize = true;
            builtByLabel.Location = new Point(3, 27);
            builtByLabel.Margin = new Padding(3, 8, 3, 0);
            builtByLabel.Name = "builtByLabel";
            builtByLabel.Size = new Size(152, 17);
            builtByLabel.TabIndex = 1;
            builtByLabel.Text = "Built By:  jsissom";
            // 
            // buildDateLabel
            // 
            buildDateLabel.AutoSize = true;
            buildDateLabel.Location = new Point(3, 47);
            buildDateLabel.Margin = new Padding(3, 3, 3, 0);
            buildDateLabel.Name = "buildDateLabel";
            buildDateLabel.Size = new Size(280, 17);
            buildDateLabel.TabIndex = 2;
            buildDateLabel.Text = "Build Date:  6/23/2023 03:31:26 PM";
            // 
            // maintenanceTabPage
            // 
            maintenanceTabPage.Controls.Add(maintenanceTableLayoutPanel);
            maintenanceTabPage.Location = new Point(4, 24);
            maintenanceTabPage.Name = "maintenanceTabPage";
            maintenanceTabPage.Padding = new Padding(3);
            maintenanceTabPage.Size = new Size(1394, 573);
            maintenanceTabPage.TabIndex = 1;
            maintenanceTabPage.Text = "Maintenance";
            maintenanceTabPage.UseVisualStyleBackColor = true;
            // 
            // maintenanceTableLayoutPanel
            // 
            maintenanceTableLayoutPanel.AutoSize = true;
            maintenanceTableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            maintenanceTableLayoutPanel.ColumnCount = 1;
            maintenanceTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            maintenanceTableLayoutPanel.Controls.Add(maintenanceConfigurationFlowLayoutPanel, 0, 0);
            maintenanceTableLayoutPanel.Controls.Add(powerManagementFlowLayoutPanel, 0, 1);
            maintenanceTableLayoutPanel.Dock = DockStyle.Fill;
            maintenanceTableLayoutPanel.Location = new Point(3, 3);
            maintenanceTableLayoutPanel.Name = "maintenanceTableLayoutPanel";
            maintenanceTableLayoutPanel.RowCount = 2;
            maintenanceTableLayoutPanel.RowStyles.Add(new RowStyle());
            maintenanceTableLayoutPanel.RowStyles.Add(new RowStyle());
            maintenanceTableLayoutPanel.Size = new Size(1388, 567);
            maintenanceTableLayoutPanel.TabIndex = 0;
            // 
            // maintenanceConfigurationFlowLayoutPanel
            // 
            maintenanceConfigurationFlowLayoutPanel.AutoSize = true;
            maintenanceConfigurationFlowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            maintenanceConfigurationFlowLayoutPanel.Controls.Add(maintenanceConfigurationLabel);
            maintenanceConfigurationFlowLayoutPanel.Controls.Add(maintenanceTimeLabel);
            maintenanceConfigurationFlowLayoutPanel.Controls.Add(lastBeganLabel);
            maintenanceConfigurationFlowLayoutPanel.Controls.Add(lastCompletedLabel);
            maintenanceConfigurationFlowLayoutPanel.Controls.Add(lastSucceededLabel);
            maintenanceConfigurationFlowLayoutPanel.Controls.Add(lastResultLabel);
            maintenanceConfigurationFlowLayoutPanel.Controls.Add(rebootPendingLabel);
            maintenanceConfigurationFlowLayoutPanel.Controls.Add(machineUpTimeLabel);
            maintenanceConfigurationFlowLayoutPanel.Dock = DockStyle.Fill;
            maintenanceConfigurationFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            maintenanceConfigurationFlowLayoutPanel.Location = new Point(3, 3);
            maintenanceConfigurationFlowLayoutPanel.Name = "maintenanceConfigurationFlowLayoutPanel";
            maintenanceConfigurationFlowLayoutPanel.Size = new Size(1382, 165);
            maintenanceConfigurationFlowLayoutPanel.TabIndex = 2;
            // 
            // maintenanceConfigurationLabel
            // 
            maintenanceConfigurationLabel.AutoSize = true;
            maintenanceConfigurationLabel.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            maintenanceConfigurationLabel.Location = new Point(3, 3);
            maintenanceConfigurationLabel.Margin = new Padding(3, 3, 3, 0);
            maintenanceConfigurationLabel.Name = "maintenanceConfigurationLabel";
            maintenanceConfigurationLabel.Size = new Size(208, 17);
            maintenanceConfigurationLabel.TabIndex = 1;
            maintenanceConfigurationLabel.Text = "Maintenance Configuration";
            // 
            // maintenanceTimeLabel
            // 
            maintenanceTimeLabel.AutoSize = true;
            maintenanceTimeLabel.Location = new Point(3, 28);
            maintenanceTimeLabel.Margin = new Padding(3, 8, 3, 0);
            maintenanceTimeLabel.Name = "maintenanceTimeLabel";
            maintenanceTimeLabel.Size = new Size(200, 17);
            maintenanceTimeLabel.TabIndex = 1;
            maintenanceTimeLabel.Text = "Maintenance Time:  17:00";
            // 
            // lastBeganLabel
            // 
            lastBeganLabel.AutoSize = true;
            lastBeganLabel.Location = new Point(3, 48);
            lastBeganLabel.Margin = new Padding(3, 3, 3, 0);
            lastBeganLabel.Name = "lastBeganLabel";
            lastBeganLabel.Size = new Size(320, 17);
            lastBeganLabel.TabIndex = 2;
            lastBeganLabel.Text = "Last Began:  Mon 10/10/2022 17:00:01:80";
            // 
            // lastCompletedLabel
            // 
            lastCompletedLabel.AutoSize = true;
            lastCompletedLabel.Location = new Point(3, 68);
            lastCompletedLabel.Margin = new Padding(3, 3, 3, 0);
            lastCompletedLabel.Name = "lastCompletedLabel";
            lastCompletedLabel.Size = new Size(352, 17);
            lastCompletedLabel.TabIndex = 3;
            lastCompletedLabel.Text = "Last Completed:  Mon 10/10/2022 17:00:34:89";
            // 
            // lastSucceededLabel
            // 
            lastSucceededLabel.AutoSize = true;
            lastSucceededLabel.Location = new Point(3, 88);
            lastSucceededLabel.Margin = new Padding(3, 3, 3, 0);
            lastSucceededLabel.Name = "lastSucceededLabel";
            lastSucceededLabel.Size = new Size(352, 17);
            lastSucceededLabel.TabIndex = 4;
            lastSucceededLabel.Text = "Last Succeeded:  Mon 10/10/2022 17:00:34:91";
            // 
            // lastResultLabel
            // 
            lastResultLabel.AutoSize = true;
            lastResultLabel.Location = new Point(3, 108);
            lastResultLabel.Margin = new Padding(3, 3, 3, 0);
            lastResultLabel.Name = "lastResultLabel";
            lastResultLabel.Size = new Size(176, 17);
            lastResultLabel.TabIndex = 5;
            lastResultLabel.Text = "Last Result:  Success";
            // 
            // rebootPendingLabel
            // 
            rebootPendingLabel.AutoSize = true;
            rebootPendingLabel.Location = new Point(3, 128);
            rebootPendingLabel.Margin = new Padding(3, 3, 3, 0);
            rebootPendingLabel.Name = "rebootPendingLabel";
            rebootPendingLabel.Size = new Size(184, 17);
            rebootPendingLabel.TabIndex = 6;
            rebootPendingLabel.Text = "Reboot Pending:  False";
            // 
            // machineUpTimeLabel
            // 
            machineUpTimeLabel.AutoSize = true;
            machineUpTimeLabel.Location = new Point(3, 148);
            machineUpTimeLabel.Margin = new Padding(3, 3, 3, 0);
            machineUpTimeLabel.Name = "machineUpTimeLabel";
            machineUpTimeLabel.Size = new Size(400, 17);
            machineUpTimeLabel.TabIndex = 7;
            machineUpTimeLabel.Text = "Machine Up Time:  7 hours, 46 minutes, 23 seconds";
            // 
            // powerManagementFlowLayoutPanel
            // 
            powerManagementFlowLayoutPanel.AutoSize = true;
            powerManagementFlowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            powerManagementFlowLayoutPanel.Controls.Add(powerManagementHeaderLabel);
            powerManagementFlowLayoutPanel.Controls.Add(systemUnitManagementLabel);
            powerManagementFlowLayoutPanel.Dock = DockStyle.Fill;
            powerManagementFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            powerManagementFlowLayoutPanel.Location = new Point(3, 174);
            powerManagementFlowLayoutPanel.Name = "powerManagementFlowLayoutPanel";
            powerManagementFlowLayoutPanel.Size = new Size(1382, 390);
            powerManagementFlowLayoutPanel.TabIndex = 3;
            // 
            // powerManagementHeaderLabel
            // 
            powerManagementHeaderLabel.AutoSize = true;
            powerManagementHeaderLabel.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            powerManagementHeaderLabel.Location = new Point(3, 3);
            powerManagementHeaderLabel.Margin = new Padding(3, 3, 3, 0);
            powerManagementHeaderLabel.Name = "powerManagementHeaderLabel";
            powerManagementHeaderLabel.Size = new Size(136, 17);
            powerManagementHeaderLabel.TabIndex = 4;
            powerManagementHeaderLabel.Text = "Power Management";
            // 
            // systemUnitManagementLabel
            // 
            systemUnitManagementLabel.AutoSize = true;
            systemUnitManagementLabel.Location = new Point(3, 28);
            systemUnitManagementLabel.Margin = new Padding(3, 8, 3, 0);
            systemUnitManagementLabel.Name = "systemUnitManagementLabel";
            systemUnitManagementLabel.Size = new Size(296, 17);
            systemUnitManagementLabel.TabIndex = 5;
            systemUnitManagementLabel.Text = "System Unit Management:  Not Managed";
            // 
            // hardwareTabPage
            // 
            hardwareTabPage.Controls.Add(hardwareTableLayoutPanel);
            hardwareTabPage.Location = new Point(4, 24);
            hardwareTabPage.Name = "hardwareTabPage";
            hardwareTabPage.Padding = new Padding(3);
            hardwareTabPage.Size = new Size(1394, 573);
            hardwareTabPage.TabIndex = 2;
            hardwareTabPage.Text = "Hardware";
            hardwareTabPage.UseVisualStyleBackColor = true;
            // 
            // hardwareTableLayoutPanel
            // 
            hardwareTableLayoutPanel.AutoScroll = true;
            hardwareTableLayoutPanel.AutoSize = true;
            hardwareTableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            hardwareTableLayoutPanel.ColumnCount = 1;
            hardwareTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            hardwareTableLayoutPanel.Controls.Add(videoControllersHeaderLabel, 0, 9);
            hardwareTableLayoutPanel.Controls.Add(logicalDisksHeaderLabel, 0, 7);
            hardwareTableLayoutPanel.Controls.Add(physicalDisksHeaderLabel, 0, 5);
            hardwareTableLayoutPanel.Controls.Add(hardwareProcessorsTable, 0, 2);
            hardwareTableLayoutPanel.Controls.Add(systemInformationPanel, 0, 0);
            hardwareTableLayoutPanel.Controls.Add(hardwareMemoryTable, 0, 4);
            hardwareTableLayoutPanel.Controls.Add(hardwarePhysicalDisksTable, 0, 6);
            hardwareTableLayoutPanel.Controls.Add(memoryHeaderLabel, 0, 3);
            hardwareTableLayoutPanel.Controls.Add(hardwareLogicalDisksTable, 0, 8);
            hardwareTableLayoutPanel.Controls.Add(processorsHeaderLabel, 0, 1);
            hardwareTableLayoutPanel.Controls.Add(hardwareVideoContollersTable, 0, 10);
            hardwareTableLayoutPanel.Dock = DockStyle.Fill;
            hardwareTableLayoutPanel.Location = new Point(3, 3);
            hardwareTableLayoutPanel.Name = "hardwareTableLayoutPanel";
            hardwareTableLayoutPanel.RowCount = 10;
            hardwareTableLayoutPanel.RowStyles.Add(new RowStyle());
            hardwareTableLayoutPanel.RowStyles.Add(new RowStyle());
            hardwareTableLayoutPanel.RowStyles.Add(new RowStyle());
            hardwareTableLayoutPanel.RowStyles.Add(new RowStyle());
            hardwareTableLayoutPanel.RowStyles.Add(new RowStyle());
            hardwareTableLayoutPanel.RowStyles.Add(new RowStyle());
            hardwareTableLayoutPanel.RowStyles.Add(new RowStyle());
            hardwareTableLayoutPanel.RowStyles.Add(new RowStyle());
            hardwareTableLayoutPanel.RowStyles.Add(new RowStyle());
            hardwareTableLayoutPanel.RowStyles.Add(new RowStyle());
            hardwareTableLayoutPanel.RowStyles.Add(new RowStyle());
            hardwareTableLayoutPanel.Size = new Size(1388, 567);
            hardwareTableLayoutPanel.TabIndex = 0;
            // 
            // videoControllersHeaderLabel
            // 
            videoControllersHeaderLabel.AutoSize = true;
            videoControllersHeaderLabel.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            videoControllersHeaderLabel.Location = new Point(3, 351);
            videoControllersHeaderLabel.Margin = new Padding(3, 8, 3, 0);
            videoControllersHeaderLabel.Name = "videoControllersHeaderLabel";
            videoControllersHeaderLabel.Size = new Size(144, 17);
            videoControllersHeaderLabel.TabIndex = 0;
            videoControllersHeaderLabel.Text = "Video Controllers";
            // 
            // logicalDisksHeaderLabel
            // 
            logicalDisksHeaderLabel.AutoSize = true;
            logicalDisksHeaderLabel.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            logicalDisksHeaderLabel.Location = new Point(3, 293);
            logicalDisksHeaderLabel.Margin = new Padding(3, 8, 3, 0);
            logicalDisksHeaderLabel.Name = "logicalDisksHeaderLabel";
            logicalDisksHeaderLabel.Size = new Size(112, 17);
            logicalDisksHeaderLabel.TabIndex = 0;
            logicalDisksHeaderLabel.Text = "Logical Disks";
            // 
            // physicalDisksHeaderLabel
            // 
            physicalDisksHeaderLabel.AutoSize = true;
            physicalDisksHeaderLabel.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            physicalDisksHeaderLabel.Location = new Point(3, 235);
            physicalDisksHeaderLabel.Margin = new Padding(3, 8, 3, 0);
            physicalDisksHeaderLabel.Name = "physicalDisksHeaderLabel";
            physicalDisksHeaderLabel.Size = new Size(120, 17);
            physicalDisksHeaderLabel.TabIndex = 0;
            physicalDisksHeaderLabel.Text = "Physical Disks";
            // 
            // hardwareProcessorsTable
            // 
            hardwareProcessorsTable.AutoSize = true;
            hardwareProcessorsTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            hardwareProcessorsTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            hardwareProcessorsTable.ColumnCount = 4;
            hardwareProcessorsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            hardwareProcessorsTable.ColumnStyles.Add(new ColumnStyle());
            hardwareProcessorsTable.ColumnStyles.Add(new ColumnStyle());
            hardwareProcessorsTable.ColumnStyles.Add(new ColumnStyle());
            hardwareProcessorsTable.Controls.Add(processorNameHeadingLabel, 0, 0);
            hardwareProcessorsTable.Controls.Add(processorTypeHeadingLabel, 1, 0);
            hardwareProcessorsTable.Controls.Add(architectureHeadingLabel, 2, 0);
            hardwareProcessorsTable.Controls.Add(cpuStatusHeadingLabel, 3, 0);
            hardwareProcessorsTable.Dock = DockStyle.Fill;
            hardwareProcessorsTable.Location = new Point(3, 138);
            hardwareProcessorsTable.Name = "hardwareProcessorsTable";
            hardwareProcessorsTable.RowCount = 2;
            hardwareProcessorsTable.RowStyles.Add(new RowStyle());
            hardwareProcessorsTable.RowStyles.Add(new RowStyle());
            hardwareProcessorsTable.Size = new Size(1382, 28);
            hardwareProcessorsTable.TabIndex = 12;
            // 
            // processorNameHeadingLabel
            // 
            processorNameHeadingLabel.AutoSize = true;
            processorNameHeadingLabel.Location = new Point(4, 9);
            processorNameHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            processorNameHeadingLabel.Name = "processorNameHeadingLabel";
            processorNameHeadingLabel.Size = new Size(40, 17);
            processorNameHeadingLabel.TabIndex = 0;
            processorNameHeadingLabel.Text = "Name";
            // 
            // processorTypeHeadingLabel
            // 
            processorTypeHeadingLabel.AutoSize = true;
            processorTypeHeadingLabel.Location = new Point(1052, 9);
            processorTypeHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            processorTypeHeadingLabel.Name = "processorTypeHeadingLabel";
            processorTypeHeadingLabel.Size = new Size(120, 17);
            processorTypeHeadingLabel.TabIndex = 1;
            processorTypeHeadingLabel.Text = "Processor Type";
            // 
            // architectureHeadingLabel
            // 
            architectureHeadingLabel.AutoSize = true;
            architectureHeadingLabel.Location = new Point(1179, 9);
            architectureHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            architectureHeadingLabel.Name = "architectureHeadingLabel";
            architectureHeadingLabel.Size = new Size(104, 17);
            architectureHeadingLabel.TabIndex = 2;
            architectureHeadingLabel.Text = "Architecture";
            // 
            // cpuStatusHeadingLabel
            // 
            cpuStatusHeadingLabel.AutoSize = true;
            cpuStatusHeadingLabel.Location = new Point(1290, 9);
            cpuStatusHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            cpuStatusHeadingLabel.Name = "cpuStatusHeadingLabel";
            cpuStatusHeadingLabel.Size = new Size(88, 17);
            cpuStatusHeadingLabel.TabIndex = 3;
            cpuStatusHeadingLabel.Text = "CPU Status";
            // 
            // systemInformationPanel
            // 
            systemInformationPanel.AutoSize = true;
            systemInformationPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            systemInformationPanel.Controls.Add(systemInformationHeaderLabel);
            systemInformationPanel.Controls.Add(modelLabel);
            systemInformationPanel.Controls.Add(manufacturerLabel);
            systemInformationPanel.Controls.Add(SMBIOSAssetTagLabel);
            systemInformationPanel.Controls.Add(serialNumberLabel);
            systemInformationPanel.Dock = DockStyle.Fill;
            systemInformationPanel.FlowDirection = FlowDirection.TopDown;
            systemInformationPanel.Location = new Point(3, 3);
            systemInformationPanel.MinimumSize = new Size(715, 20);
            systemInformationPanel.Name = "systemInformationPanel";
            systemInformationPanel.Size = new Size(1382, 104);
            systemInformationPanel.TabIndex = 0;
            // 
            // systemInformationHeaderLabel
            // 
            systemInformationHeaderLabel.AutoSize = true;
            systemInformationHeaderLabel.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            systemInformationHeaderLabel.Location = new Point(3, 2);
            systemInformationHeaderLabel.Margin = new Padding(3, 2, 3, 0);
            systemInformationHeaderLabel.Name = "systemInformationHeaderLabel";
            systemInformationHeaderLabel.Size = new Size(152, 17);
            systemInformationHeaderLabel.TabIndex = 0;
            systemInformationHeaderLabel.Text = "System Information";
            // 
            // modelLabel
            // 
            modelLabel.AutoSize = true;
            modelLabel.Location = new Point(3, 27);
            modelLabel.Margin = new Padding(3, 8, 3, 0);
            modelLabel.Name = "modelLabel";
            modelLabel.Size = new Size(184, 17);
            modelLabel.TabIndex = 1;
            modelLabel.Text = "System:  Latitude 5420";
            // 
            // manufacturerLabel
            // 
            manufacturerLabel.AutoSize = true;
            manufacturerLabel.Location = new Point(3, 47);
            manufacturerLabel.Margin = new Padding(3, 3, 3, 0);
            manufacturerLabel.Name = "manufacturerLabel";
            manufacturerLabel.Size = new Size(200, 17);
            manufacturerLabel.TabIndex = 2;
            manufacturerLabel.Text = "Manufacturer:  Dell Inc.";
            // 
            // SMBIOSAssetTagLabel
            // 
            SMBIOSAssetTagLabel.AutoSize = true;
            SMBIOSAssetTagLabel.Location = new Point(3, 67);
            SMBIOSAssetTagLabel.Margin = new Padding(3, 3, 3, 0);
            SMBIOSAssetTagLabel.Name = "SMBIOSAssetTagLabel";
            SMBIOSAssetTagLabel.Size = new Size(160, 17);
            SMBIOSAssetTagLabel.TabIndex = 3;
            SMBIOSAssetTagLabel.Text = "Asset Tag:  1005917";
            // 
            // serialNumberLabel
            // 
            serialNumberLabel.AutoSize = true;
            serialNumberLabel.Location = new Point(3, 87);
            serialNumberLabel.Margin = new Padding(3, 3, 3, 0);
            serialNumberLabel.Name = "serialNumberLabel";
            serialNumberLabel.Size = new Size(176, 17);
            serialNumberLabel.TabIndex = 4;
            serialNumberLabel.Text = "Service Tag:  J17L3F3";
            // 
            // hardwareMemoryTable
            // 
            hardwareMemoryTable.AutoSize = true;
            hardwareMemoryTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            hardwareMemoryTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            hardwareMemoryTable.ColumnCount = 4;
            hardwareMemoryTable.ColumnStyles.Add(new ColumnStyle());
            hardwareMemoryTable.ColumnStyles.Add(new ColumnStyle());
            hardwareMemoryTable.ColumnStyles.Add(new ColumnStyle());
            hardwareMemoryTable.ColumnStyles.Add(new ColumnStyle());
            hardwareMemoryTable.Controls.Add(memoryNameHeadingLabel, 0, 0);
            hardwareMemoryTable.Controls.Add(memoryCapacityLabel, 1, 0);
            hardwareMemoryTable.Controls.Add(memorySpeedLabel, 2, 0);
            hardwareMemoryTable.Controls.Add(memoryTypeLabel, 3, 0);
            hardwareMemoryTable.Dock = DockStyle.Fill;
            hardwareMemoryTable.Location = new Point(3, 197);
            hardwareMemoryTable.Name = "hardwareMemoryTable";
            hardwareMemoryTable.RowCount = 1;
            hardwareMemoryTable.RowStyles.Add(new RowStyle());
            hardwareMemoryTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            hardwareMemoryTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            hardwareMemoryTable.Size = new Size(1382, 27);
            hardwareMemoryTable.TabIndex = 8;
            // 
            // memoryNameHeadingLabel
            // 
            memoryNameHeadingLabel.AutoSize = true;
            memoryNameHeadingLabel.Location = new Point(4, 9);
            memoryNameHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            memoryNameHeadingLabel.Name = "memoryNameHeadingLabel";
            memoryNameHeadingLabel.Size = new Size(40, 17);
            memoryNameHeadingLabel.TabIndex = 0;
            memoryNameHeadingLabel.Text = "Name";
            // 
            // memoryCapacityLabel
            // 
            memoryCapacityLabel.AutoSize = true;
            memoryCapacityLabel.Location = new Point(51, 9);
            memoryCapacityLabel.Margin = new Padding(3, 8, 3, 0);
            memoryCapacityLabel.Name = "memoryCapacityLabel";
            memoryCapacityLabel.Size = new Size(72, 17);
            memoryCapacityLabel.TabIndex = 1;
            memoryCapacityLabel.Text = "Capacity";
            // 
            // memorySpeedLabel
            // 
            memorySpeedLabel.AutoSize = true;
            memorySpeedLabel.Location = new Point(130, 9);
            memorySpeedLabel.Margin = new Padding(3, 8, 3, 0);
            memorySpeedLabel.Name = "memorySpeedLabel";
            memorySpeedLabel.Size = new Size(48, 17);
            memorySpeedLabel.TabIndex = 2;
            memorySpeedLabel.Text = "Speed";
            // 
            // memoryTypeLabel
            // 
            memoryTypeLabel.AutoSize = true;
            memoryTypeLabel.Location = new Point(185, 9);
            memoryTypeLabel.Margin = new Padding(3, 8, 3, 0);
            memoryTypeLabel.Name = "memoryTypeLabel";
            memoryTypeLabel.Size = new Size(40, 17);
            memoryTypeLabel.TabIndex = 3;
            memoryTypeLabel.Text = "Type";
            // 
            // hardwarePhysicalDisksTable
            // 
            hardwarePhysicalDisksTable.AutoSize = true;
            hardwarePhysicalDisksTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            hardwarePhysicalDisksTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            hardwarePhysicalDisksTable.ColumnCount = 5;
            hardwarePhysicalDisksTable.ColumnStyles.Add(new ColumnStyle());
            hardwarePhysicalDisksTable.ColumnStyles.Add(new ColumnStyle());
            hardwarePhysicalDisksTable.ColumnStyles.Add(new ColumnStyle());
            hardwarePhysicalDisksTable.ColumnStyles.Add(new ColumnStyle());
            hardwarePhysicalDisksTable.ColumnStyles.Add(new ColumnStyle());
            hardwarePhysicalDisksTable.Controls.Add(hardDriveNameHeadingLabel, 0, 0);
            hardwarePhysicalDisksTable.Controls.Add(hardDriveModelHeadingLabel, 1, 0);
            hardwarePhysicalDisksTable.Controls.Add(hardDriveSizeHeadingLabel, 2, 0);
            hardwarePhysicalDisksTable.Controls.Add(hardDriveTypeHeadingLabel, 3, 0);
            hardwarePhysicalDisksTable.Controls.Add(hardDrivePartitionsHeadingLabel, 4, 0);
            hardwarePhysicalDisksTable.Dock = DockStyle.Fill;
            hardwarePhysicalDisksTable.Location = new Point(3, 255);
            hardwarePhysicalDisksTable.Name = "hardwarePhysicalDisksTable";
            hardwarePhysicalDisksTable.RowCount = 1;
            hardwarePhysicalDisksTable.RowStyles.Add(new RowStyle());
            hardwarePhysicalDisksTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            hardwarePhysicalDisksTable.Size = new Size(1382, 27);
            hardwarePhysicalDisksTable.TabIndex = 10;
            // 
            // hardDriveNameHeadingLabel
            // 
            hardDriveNameHeadingLabel.AutoSize = true;
            hardDriveNameHeadingLabel.Location = new Point(4, 9);
            hardDriveNameHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            hardDriveNameHeadingLabel.Name = "hardDriveNameHeadingLabel";
            hardDriveNameHeadingLabel.Size = new Size(40, 17);
            hardDriveNameHeadingLabel.TabIndex = 1;
            hardDriveNameHeadingLabel.Text = "Name";
            // 
            // hardDriveModelHeadingLabel
            // 
            hardDriveModelHeadingLabel.AutoSize = true;
            hardDriveModelHeadingLabel.Location = new Point(51, 9);
            hardDriveModelHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            hardDriveModelHeadingLabel.Name = "hardDriveModelHeadingLabel";
            hardDriveModelHeadingLabel.Size = new Size(48, 17);
            hardDriveModelHeadingLabel.TabIndex = 2;
            hardDriveModelHeadingLabel.Text = "Model";
            // 
            // hardDriveSizeHeadingLabel
            // 
            hardDriveSizeHeadingLabel.AutoSize = true;
            hardDriveSizeHeadingLabel.Location = new Point(106, 9);
            hardDriveSizeHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            hardDriveSizeHeadingLabel.Name = "hardDriveSizeHeadingLabel";
            hardDriveSizeHeadingLabel.Size = new Size(40, 17);
            hardDriveSizeHeadingLabel.TabIndex = 3;
            hardDriveSizeHeadingLabel.Text = "Size";
            // 
            // hardDriveTypeHeadingLabel
            // 
            hardDriveTypeHeadingLabel.AutoSize = true;
            hardDriveTypeHeadingLabel.Location = new Point(153, 9);
            hardDriveTypeHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            hardDriveTypeHeadingLabel.Name = "hardDriveTypeHeadingLabel";
            hardDriveTypeHeadingLabel.Size = new Size(40, 17);
            hardDriveTypeHeadingLabel.TabIndex = 4;
            hardDriveTypeHeadingLabel.Text = "Type";
            // 
            // hardDrivePartitionsHeadingLabel
            // 
            hardDrivePartitionsHeadingLabel.AutoSize = true;
            hardDrivePartitionsHeadingLabel.Location = new Point(200, 9);
            hardDrivePartitionsHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            hardDrivePartitionsHeadingLabel.Name = "hardDrivePartitionsHeadingLabel";
            hardDrivePartitionsHeadingLabel.Size = new Size(88, 17);
            hardDrivePartitionsHeadingLabel.TabIndex = 5;
            hardDrivePartitionsHeadingLabel.Text = "Partitions";
            // 
            // memoryHeaderLabel
            // 
            memoryHeaderLabel.AutoSize = true;
            memoryHeaderLabel.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            memoryHeaderLabel.Location = new Point(3, 177);
            memoryHeaderLabel.Margin = new Padding(3, 8, 3, 0);
            memoryHeaderLabel.Name = "memoryHeaderLabel";
            memoryHeaderLabel.Size = new Size(56, 17);
            memoryHeaderLabel.TabIndex = 4;
            memoryHeaderLabel.Text = "Memory";
            // 
            // hardwareLogicalDisksTable
            // 
            hardwareLogicalDisksTable.AutoSize = true;
            hardwareLogicalDisksTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            hardwareLogicalDisksTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            hardwareLogicalDisksTable.ColumnCount = 7;
            hardwareLogicalDisksTable.ColumnStyles.Add(new ColumnStyle());
            hardwareLogicalDisksTable.ColumnStyles.Add(new ColumnStyle());
            hardwareLogicalDisksTable.ColumnStyles.Add(new ColumnStyle());
            hardwareLogicalDisksTable.ColumnStyles.Add(new ColumnStyle());
            hardwareLogicalDisksTable.ColumnStyles.Add(new ColumnStyle());
            hardwareLogicalDisksTable.ColumnStyles.Add(new ColumnStyle());
            hardwareLogicalDisksTable.ColumnStyles.Add(new ColumnStyle());
            hardwareLogicalDisksTable.Controls.Add(diskDriveIdHeadingLabel, 0, 0);
            hardwareLogicalDisksTable.Controls.Add(diskDriveNameHeadingLabel, 1, 0);
            hardwareLogicalDisksTable.Controls.Add(diskDriveFileSystemHeadingLabel, 2, 0);
            hardwareLogicalDisksTable.Controls.Add(diskDriveDriveTypeHeadingLabel, 3, 0);
            hardwareLogicalDisksTable.Controls.Add(diskDriveMediaTypeHeadingLabel, 4, 0);
            hardwareLogicalDisksTable.Controls.Add(diskDriveFreeSpaceHeadingLabel, 5, 0);
            hardwareLogicalDisksTable.Controls.Add(diskDriveCapacityHeadingLabel, 6, 0);
            hardwareLogicalDisksTable.Dock = DockStyle.Fill;
            hardwareLogicalDisksTable.Location = new Point(3, 313);
            hardwareLogicalDisksTable.Name = "hardwareLogicalDisksTable";
            hardwareLogicalDisksTable.RowCount = 1;
            hardwareLogicalDisksTable.RowStyles.Add(new RowStyle());
            hardwareLogicalDisksTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            hardwareLogicalDisksTable.Size = new Size(1382, 27);
            hardwareLogicalDisksTable.TabIndex = 11;
            // 
            // diskDriveIdHeadingLabel
            // 
            diskDriveIdHeadingLabel.AutoSize = true;
            diskDriveIdHeadingLabel.Location = new Point(4, 9);
            diskDriveIdHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            diskDriveIdHeadingLabel.Name = "diskDriveIdHeadingLabel";
            diskDriveIdHeadingLabel.Size = new Size(24, 17);
            diskDriveIdHeadingLabel.TabIndex = 1;
            diskDriveIdHeadingLabel.Text = "ID";
            // 
            // diskDriveNameHeadingLabel
            // 
            diskDriveNameHeadingLabel.AutoSize = true;
            diskDriveNameHeadingLabel.Location = new Point(35, 9);
            diskDriveNameHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            diskDriveNameHeadingLabel.Name = "diskDriveNameHeadingLabel";
            diskDriveNameHeadingLabel.Size = new Size(40, 17);
            diskDriveNameHeadingLabel.TabIndex = 2;
            diskDriveNameHeadingLabel.Text = "Name";
            // 
            // diskDriveFileSystemHeadingLabel
            // 
            diskDriveFileSystemHeadingLabel.AutoSize = true;
            diskDriveFileSystemHeadingLabel.Location = new Point(82, 9);
            diskDriveFileSystemHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            diskDriveFileSystemHeadingLabel.Name = "diskDriveFileSystemHeadingLabel";
            diskDriveFileSystemHeadingLabel.Size = new Size(96, 17);
            diskDriveFileSystemHeadingLabel.TabIndex = 3;
            diskDriveFileSystemHeadingLabel.Text = "File System";
            // 
            // diskDriveDriveTypeHeadingLabel
            // 
            diskDriveDriveTypeHeadingLabel.AutoSize = true;
            diskDriveDriveTypeHeadingLabel.Location = new Point(185, 9);
            diskDriveDriveTypeHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            diskDriveDriveTypeHeadingLabel.Name = "diskDriveDriveTypeHeadingLabel";
            diskDriveDriveTypeHeadingLabel.Size = new Size(88, 17);
            diskDriveDriveTypeHeadingLabel.TabIndex = 4;
            diskDriveDriveTypeHeadingLabel.Text = "Drive Type";
            // 
            // diskDriveMediaTypeHeadingLabel
            // 
            diskDriveMediaTypeHeadingLabel.AutoSize = true;
            diskDriveMediaTypeHeadingLabel.Location = new Point(280, 9);
            diskDriveMediaTypeHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            diskDriveMediaTypeHeadingLabel.Name = "diskDriveMediaTypeHeadingLabel";
            diskDriveMediaTypeHeadingLabel.Size = new Size(88, 17);
            diskDriveMediaTypeHeadingLabel.TabIndex = 5;
            diskDriveMediaTypeHeadingLabel.Text = "Media Type";
            // 
            // diskDriveFreeSpaceHeadingLabel
            // 
            diskDriveFreeSpaceHeadingLabel.AutoSize = true;
            diskDriveFreeSpaceHeadingLabel.Location = new Point(375, 9);
            diskDriveFreeSpaceHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            diskDriveFreeSpaceHeadingLabel.Name = "diskDriveFreeSpaceHeadingLabel";
            diskDriveFreeSpaceHeadingLabel.Size = new Size(88, 17);
            diskDriveFreeSpaceHeadingLabel.TabIndex = 6;
            diskDriveFreeSpaceHeadingLabel.Text = "Free Space";
            // 
            // diskDriveCapacityHeadingLabel
            // 
            diskDriveCapacityHeadingLabel.AutoSize = true;
            diskDriveCapacityHeadingLabel.Location = new Point(470, 9);
            diskDriveCapacityHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            diskDriveCapacityHeadingLabel.Name = "diskDriveCapacityHeadingLabel";
            diskDriveCapacityHeadingLabel.Size = new Size(72, 17);
            diskDriveCapacityHeadingLabel.TabIndex = 7;
            diskDriveCapacityHeadingLabel.Text = "Capacity";
            // 
            // processorsHeaderLabel
            // 
            processorsHeaderLabel.AutoSize = true;
            processorsHeaderLabel.BackColor = Color.Transparent;
            processorsHeaderLabel.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            processorsHeaderLabel.Location = new Point(3, 118);
            processorsHeaderLabel.Margin = new Padding(3, 8, 3, 0);
            processorsHeaderLabel.Name = "processorsHeaderLabel";
            processorsHeaderLabel.Size = new Size(88, 17);
            processorsHeaderLabel.TabIndex = 14;
            processorsHeaderLabel.Text = "Processors";
            // 
            // hardwareVideoContollersTable
            // 
            hardwareVideoContollersTable.AutoSize = true;
            hardwareVideoContollersTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            hardwareVideoContollersTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            hardwareVideoContollersTable.ColumnCount = 6;
            hardwareVideoContollersTable.ColumnStyles.Add(new ColumnStyle());
            hardwareVideoContollersTable.ColumnStyles.Add(new ColumnStyle());
            hardwareVideoContollersTable.ColumnStyles.Add(new ColumnStyle());
            hardwareVideoContollersTable.ColumnStyles.Add(new ColumnStyle());
            hardwareVideoContollersTable.ColumnStyles.Add(new ColumnStyle());
            hardwareVideoContollersTable.ColumnStyles.Add(new ColumnStyle());
            hardwareVideoContollersTable.Controls.Add(videoControllerNameHeadingLabel, 0, 0);
            hardwareVideoContollersTable.Controls.Add(videoControllerRamHeadingLabel, 1, 0);
            hardwareVideoContollersTable.Controls.Add(videoControllerBitsPerPixelHeadingLabel, 2, 0);
            hardwareVideoContollersTable.Controls.Add(videoControllerDriverVersionHeadingLabel, 3, 0);
            hardwareVideoContollersTable.Controls.Add(videoControllerDriverDateHeadingLabel, 4, 0);
            hardwareVideoContollersTable.Controls.Add(videoControllerVideoProcessorHeadingLabel, 5, 0);
            hardwareVideoContollersTable.Dock = DockStyle.Fill;
            hardwareVideoContollersTable.Location = new Point(3, 371);
            hardwareVideoContollersTable.Name = "hardwareVideoContollersTable";
            hardwareVideoContollersTable.RowCount = 1;
            hardwareVideoContollersTable.RowStyles.Add(new RowStyle());
            hardwareVideoContollersTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            hardwareVideoContollersTable.Size = new Size(1382, 193);
            hardwareVideoContollersTable.TabIndex = 13;
            // 
            // videoControllerNameHeadingLabel
            // 
            videoControllerNameHeadingLabel.AutoSize = true;
            videoControllerNameHeadingLabel.Location = new Point(4, 9);
            videoControllerNameHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            videoControllerNameHeadingLabel.Name = "videoControllerNameHeadingLabel";
            videoControllerNameHeadingLabel.Size = new Size(40, 17);
            videoControllerNameHeadingLabel.TabIndex = 1;
            videoControllerNameHeadingLabel.Text = "Name";
            // 
            // videoControllerRamHeadingLabel
            // 
            videoControllerRamHeadingLabel.AutoSize = true;
            videoControllerRamHeadingLabel.Location = new Point(51, 9);
            videoControllerRamHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            videoControllerRamHeadingLabel.Name = "videoControllerRamHeadingLabel";
            videoControllerRamHeadingLabel.Size = new Size(32, 17);
            videoControllerRamHeadingLabel.TabIndex = 2;
            videoControllerRamHeadingLabel.Text = "RAM";
            // 
            // videoControllerBitsPerPixelHeadingLabel
            // 
            videoControllerBitsPerPixelHeadingLabel.AutoSize = true;
            videoControllerBitsPerPixelHeadingLabel.Location = new Point(90, 9);
            videoControllerBitsPerPixelHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            videoControllerBitsPerPixelHeadingLabel.Name = "videoControllerBitsPerPixelHeadingLabel";
            videoControllerBitsPerPixelHeadingLabel.Size = new Size(120, 17);
            videoControllerBitsPerPixelHeadingLabel.TabIndex = 3;
            videoControllerBitsPerPixelHeadingLabel.Text = "Bits Per Pixel";
            // 
            // videoControllerDriverVersionHeadingLabel
            // 
            videoControllerDriverVersionHeadingLabel.AutoSize = true;
            videoControllerDriverVersionHeadingLabel.Location = new Point(217, 9);
            videoControllerDriverVersionHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            videoControllerDriverVersionHeadingLabel.Name = "videoControllerDriverVersionHeadingLabel";
            videoControllerDriverVersionHeadingLabel.Size = new Size(120, 17);
            videoControllerDriverVersionHeadingLabel.TabIndex = 4;
            videoControllerDriverVersionHeadingLabel.Text = "Driver Version";
            // 
            // videoControllerDriverDateHeadingLabel
            // 
            videoControllerDriverDateHeadingLabel.AutoSize = true;
            videoControllerDriverDateHeadingLabel.Location = new Point(344, 9);
            videoControllerDriverDateHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            videoControllerDriverDateHeadingLabel.Name = "videoControllerDriverDateHeadingLabel";
            videoControllerDriverDateHeadingLabel.Size = new Size(96, 17);
            videoControllerDriverDateHeadingLabel.TabIndex = 5;
            videoControllerDriverDateHeadingLabel.Text = "Driver Date";
            // 
            // videoControllerVideoProcessorHeadingLabel
            // 
            videoControllerVideoProcessorHeadingLabel.AutoSize = true;
            videoControllerVideoProcessorHeadingLabel.Location = new Point(447, 9);
            videoControllerVideoProcessorHeadingLabel.Margin = new Padding(3, 8, 3, 0);
            videoControllerVideoProcessorHeadingLabel.Name = "videoControllerVideoProcessorHeadingLabel";
            videoControllerVideoProcessorHeadingLabel.Size = new Size(128, 17);
            videoControllerVideoProcessorHeadingLabel.TabIndex = 6;
            videoControllerVideoProcessorHeadingLabel.Text = "Video Processor";
            // 
            // biosTabPage
            // 
            biosTabPage.Controls.Add(biosTable);
            biosTabPage.Location = new Point(4, 24);
            biosTabPage.Name = "biosTabPage";
            biosTabPage.Padding = new Padding(3);
            biosTabPage.Size = new Size(1394, 573);
            biosTabPage.TabIndex = 3;
            biosTabPage.Text = "BIOS";
            biosTabPage.UseVisualStyleBackColor = true;
            // 
            // biosTable
            // 
            biosTable.AutoScroll = true;
            biosTable.AutoSize = true;
            biosTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            biosTable.ColumnCount = 1;
            biosTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            biosTable.Controls.Add(biosInformationHeader, 0, 0);
            biosTable.Controls.Add(biosInformationPanel, 0, 1);
            biosTable.Controls.Add(bootOrderHeader, 0, 2);
            biosTable.Controls.Add(bootOrderPanel, 0, 3);
            biosTable.Controls.Add(biosSettingsHeader, 0, 4);
            biosTable.Controls.Add(biosSettingsTable, 0, 5);
            biosTable.Dock = DockStyle.Fill;
            biosTable.Location = new Point(3, 3);
            biosTable.Name = "biosTable";
            biosTable.RowCount = 6;
            biosTable.RowStyles.Add(new RowStyle());
            biosTable.RowStyles.Add(new RowStyle());
            biosTable.RowStyles.Add(new RowStyle());
            biosTable.RowStyles.Add(new RowStyle());
            biosTable.RowStyles.Add(new RowStyle());
            biosTable.RowStyles.Add(new RowStyle());
            biosTable.Size = new Size(1388, 567);
            biosTable.TabIndex = 0;
            // 
            // biosInformationHeader
            // 
            biosInformationHeader.AutoSize = true;
            biosInformationHeader.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            biosInformationHeader.Location = new Point(3, 3);
            biosInformationHeader.Margin = new Padding(3);
            biosInformationHeader.Name = "biosInformationHeader";
            biosInformationHeader.Size = new Size(136, 17);
            biosInformationHeader.TabIndex = 0;
            biosInformationHeader.Text = "BIOS Information";
            // 
            // biosInformationPanel
            // 
            biosInformationPanel.AutoSize = true;
            biosInformationPanel.Dock = DockStyle.Fill;
            biosInformationPanel.FlowDirection = FlowDirection.TopDown;
            biosInformationPanel.Location = new Point(3, 26);
            biosInformationPanel.Name = "biosInformationPanel";
            biosInformationPanel.Size = new Size(1382, 1);
            biosInformationPanel.TabIndex = 1;
            // 
            // bootOrderHeader
            // 
            bootOrderHeader.AutoSize = true;
            bootOrderHeader.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            bootOrderHeader.Location = new Point(3, 32);
            bootOrderHeader.Margin = new Padding(3);
            bootOrderHeader.Name = "bootOrderHeader";
            bootOrderHeader.Size = new Size(88, 17);
            bootOrderHeader.TabIndex = 2;
            bootOrderHeader.Text = "Boot Order";
            // 
            // bootOrderPanel
            // 
            bootOrderPanel.AutoSize = true;
            bootOrderPanel.Dock = DockStyle.Fill;
            bootOrderPanel.Location = new Point(3, 55);
            bootOrderPanel.Name = "bootOrderPanel";
            bootOrderPanel.Size = new Size(1382, 1);
            bootOrderPanel.TabIndex = 3;
            // 
            // biosSettingsHeader
            // 
            biosSettingsHeader.AutoSize = true;
            biosSettingsHeader.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            biosSettingsHeader.Location = new Point(3, 61);
            biosSettingsHeader.Margin = new Padding(3);
            biosSettingsHeader.Name = "biosSettingsHeader";
            biosSettingsHeader.Size = new Size(112, 17);
            biosSettingsHeader.TabIndex = 4;
            biosSettingsHeader.Text = "BIOS Settings";
            // 
            // biosSettingsTable
            // 
            biosSettingsTable.AutoScroll = true;
            biosSettingsTable.AutoSize = true;
            biosSettingsTable.BackgroundImageLayout = ImageLayout.Stretch;
            biosSettingsTable.ColumnCount = 3;
            biosSettingsTable.ColumnStyles.Add(new ColumnStyle());
            biosSettingsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            biosSettingsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            biosSettingsTable.Controls.Add(biosAttributeName, 0, 0);
            biosSettingsTable.Controls.Add(biosCurrentValue, 1, 0);
            biosSettingsTable.Controls.Add(biosPossibleValues, 2, 0);
            biosSettingsTable.Dock = DockStyle.Fill;
            biosSettingsTable.Location = new Point(3, 84);
            biosSettingsTable.Name = "biosSettingsTable";
            biosSettingsTable.RowCount = 1;
            biosSettingsTable.RowStyles.Add(new RowStyle());
            biosSettingsTable.Size = new Size(1382, 480);
            biosSettingsTable.TabIndex = 5;
            // 
            // biosAttributeName
            // 
            biosAttributeName.AutoSize = true;
            biosAttributeName.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            biosAttributeName.Location = new Point(3, 3);
            biosAttributeName.Margin = new Padding(3);
            biosAttributeName.Name = "biosAttributeName";
            biosAttributeName.Size = new Size(120, 17);
            biosAttributeName.TabIndex = 0;
            biosAttributeName.Text = "Attribute Name";
            // 
            // biosCurrentValue
            // 
            biosCurrentValue.AutoSize = true;
            biosCurrentValue.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            biosCurrentValue.Location = new Point(129, 3);
            biosCurrentValue.Margin = new Padding(3);
            biosCurrentValue.Name = "biosCurrentValue";
            biosCurrentValue.Size = new Size(112, 17);
            biosCurrentValue.TabIndex = 1;
            biosCurrentValue.Text = "Current Value";
            // 
            // biosPossibleValues
            // 
            biosPossibleValues.AutoSize = true;
            biosPossibleValues.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            biosPossibleValues.Location = new Point(757, 3);
            biosPossibleValues.Margin = new Padding(3);
            biosPossibleValues.Name = "biosPossibleValues";
            biosPossibleValues.Size = new Size(128, 17);
            biosPossibleValues.TabIndex = 2;
            biosPossibleValues.Text = "Possible Values";
            // 
            // networkTabPage
            // 
            networkTabPage.Controls.Add(networkTable);
            networkTabPage.Location = new Point(4, 24);
            networkTabPage.Name = "networkTabPage";
            networkTabPage.Padding = new Padding(3);
            networkTabPage.Size = new Size(1394, 573);
            networkTabPage.TabIndex = 4;
            networkTabPage.Text = "Network";
            networkTabPage.UseVisualStyleBackColor = true;
            // 
            // networkTable
            // 
            networkTable.AutoSize = true;
            networkTable.ColumnCount = 1;
            networkTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            networkTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            networkTable.Controls.Add(networkAdaptersHeader, 0, 0);
            networkTable.Controls.Add(ipConfigurationHeader, 0, 2);
            networkTable.Controls.Add(networkAdaptersTable, 0, 1);
            networkTable.Controls.Add(ipConfigurationTable, 0, 3);
            networkTable.Dock = DockStyle.Fill;
            networkTable.Location = new Point(3, 3);
            networkTable.Name = "networkTable";
            networkTable.RowCount = 4;
            networkTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            networkTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            networkTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            networkTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            networkTable.Size = new Size(1388, 567);
            networkTable.TabIndex = 0;
            // 
            // networkAdaptersHeader
            // 
            networkAdaptersHeader.AutoSize = true;
            networkAdaptersHeader.Location = new Point(3, 0);
            networkAdaptersHeader.Name = "networkAdaptersHeader";
            networkAdaptersHeader.Size = new Size(136, 17);
            networkAdaptersHeader.TabIndex = 0;
            networkAdaptersHeader.Text = "Network Adapters";
            // 
            // ipConfigurationHeader
            // 
            ipConfigurationHeader.AutoSize = true;
            ipConfigurationHeader.Location = new Point(3, 283);
            ipConfigurationHeader.Name = "ipConfigurationHeader";
            ipConfigurationHeader.Size = new Size(136, 17);
            ipConfigurationHeader.TabIndex = 1;
            ipConfigurationHeader.Text = "IP Configuration";
            // 
            // networkAdaptersTable
            // 
            networkAdaptersTable.AutoSize = true;
            networkAdaptersTable.ColumnCount = 2;
            networkAdaptersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            networkAdaptersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            networkAdaptersTable.Dock = DockStyle.Fill;
            networkAdaptersTable.Location = new Point(3, 23);
            networkAdaptersTable.Name = "networkAdaptersTable";
            networkAdaptersTable.RowCount = 2;
            networkAdaptersTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            networkAdaptersTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            networkAdaptersTable.Size = new Size(1382, 257);
            networkAdaptersTable.TabIndex = 2;
            // 
            // ipConfigurationTable
            // 
            ipConfigurationTable.AutoSize = true;
            ipConfigurationTable.ColumnCount = 2;
            ipConfigurationTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ipConfigurationTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ipConfigurationTable.Dock = DockStyle.Fill;
            ipConfigurationTable.Location = new Point(3, 306);
            ipConfigurationTable.Name = "ipConfigurationTable";
            ipConfigurationTable.RowCount = 2;
            ipConfigurationTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            ipConfigurationTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            ipConfigurationTable.Size = new Size(1382, 258);
            ipConfigurationTable.TabIndex = 3;
            // 
            // printersTabPage
            // 
            printersTabPage.Controls.Add(printerTable);
            printersTabPage.Location = new Point(4, 26);
            printersTabPage.Name = "printersTabPage";
            printersTabPage.Padding = new Padding(3);
            printersTabPage.Size = new Size(1394, 571);
            printersTabPage.TabIndex = 5;
            printersTabPage.Text = "Printers";
            printersTabPage.UseVisualStyleBackColor = true;
            printersTabPage.MouseClick += printersTabPage_MouseClick;
            // 
            // printerTable
            // 
            printerTable.ColumnCount = 1;
            printerTable.ColumnStyles.Add(new ColumnStyle());
            printerTable.Controls.Add(installedPrintersHeader, 0, 0);
            printerTable.Controls.Add(printerDeafultHeader, 0, 2);
            printerTable.Controls.Add(installedPrinterTable, 0, 1);
            printerTable.Controls.Add(defaultPrinterTable, 0, 3);
            printerTable.Dock = DockStyle.Fill;
            printerTable.Location = new Point(3, 3);
            printerTable.Name = "printerTable";
            printerTable.RowCount = 4;
            printerTable.RowStyles.Add(new RowStyle());
            printerTable.RowStyles.Add(new RowStyle());
            printerTable.RowStyles.Add(new RowStyle());
            printerTable.RowStyles.Add(new RowStyle());
            printerTable.Size = new Size(1388, 565);
            printerTable.TabIndex = 0;
            printerTable.MouseClick += printerTable_MouseClick;
            // 
            // installedPrintersHeader
            // 
            installedPrintersHeader.AutoSize = true;
            installedPrintersHeader.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            installedPrintersHeader.Location = new Point(3, 3);
            installedPrintersHeader.Margin = new Padding(3, 3, 3, 0);
            installedPrintersHeader.Name = "installedPrintersHeader";
            installedPrintersHeader.Size = new Size(152, 17);
            installedPrintersHeader.TabIndex = 0;
            installedPrintersHeader.Text = "Installed Printers";
            // 
            // printerDeafultHeader
            // 
            printerDeafultHeader.AutoSize = true;
            printerDeafultHeader.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            printerDeafultHeader.Location = new Point(3, 52);
            printerDeafultHeader.Margin = new Padding(3, 6, 3, 0);
            printerDeafultHeader.Name = "printerDeafultHeader";
            printerDeafultHeader.Size = new Size(136, 17);
            printerDeafultHeader.TabIndex = 1;
            printerDeafultHeader.Text = "Printer Defaults";
            // 
            // installedPrinterTable
            // 
            installedPrinterTable.AutoSize = true;
            installedPrinterTable.ColumnCount = 4;
            installedPrinterTable.ColumnStyles.Add(new ColumnStyle());
            installedPrinterTable.ColumnStyles.Add(new ColumnStyle());
            installedPrinterTable.ColumnStyles.Add(new ColumnStyle());
            installedPrinterTable.ColumnStyles.Add(new ColumnStyle());
            installedPrinterTable.Controls.Add(label1, 1, 0);
            installedPrinterTable.Controls.Add(label2, 2, 0);
            installedPrinterTable.Controls.Add(label3, 3, 0);
            installedPrinterTable.Dock = DockStyle.Fill;
            installedPrinterTable.Location = new Point(3, 23);
            installedPrinterTable.Name = "installedPrinterTable";
            installedPrinterTable.RowCount = 1;
            installedPrinterTable.RowStyles.Add(new RowStyle());
            installedPrinterTable.Size = new Size(1382, 20);
            installedPrinterTable.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 3);
            label1.Margin = new Padding(3, 3, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(80, 17);
            label1.TabIndex = 0;
            label1.Text = "Device ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(89, 3);
            label2.Margin = new Padding(3, 3, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(96, 17);
            label2.TabIndex = 1;
            label2.Text = "Driver Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(191, 3);
            label3.Margin = new Padding(3, 3, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(80, 17);
            label3.TabIndex = 2;
            label3.Text = "Port Name";
            // 
            // defaultPrinterTable
            // 
            defaultPrinterTable.AutoSize = true;
            defaultPrinterTable.ColumnCount = 2;
            defaultPrinterTable.ColumnStyles.Add(new ColumnStyle());
            defaultPrinterTable.ColumnStyles.Add(new ColumnStyle());
            defaultPrinterTable.Controls.Add(label4, 0, 0);
            defaultPrinterTable.Controls.Add(label5, 1, 0);
            defaultPrinterTable.Dock = DockStyle.Fill;
            defaultPrinterTable.Location = new Point(3, 72);
            defaultPrinterTable.Name = "defaultPrinterTable";
            defaultPrinterTable.RowCount = 1;
            defaultPrinterTable.RowStyles.Add(new RowStyle());
            defaultPrinterTable.Size = new Size(1382, 490);
            defaultPrinterTable.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(3, 3);
            label4.Margin = new Padding(3, 3, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(112, 17);
            label4.TabIndex = 0;
            label4.Text = "User Account ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(121, 3);
            label5.Margin = new Padding(3, 3, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(80, 17);
            label5.TabIndex = 1;
            label5.Text = "Device ID";
            // 
            // securityTabPage
            // 
            securityTabPage.Controls.Add(securityTable);
            securityTabPage.Location = new Point(4, 24);
            securityTabPage.Name = "securityTabPage";
            securityTabPage.Padding = new Padding(3);
            securityTabPage.Size = new Size(1394, 573);
            securityTabPage.TabIndex = 6;
            securityTabPage.Text = "Security";
            securityTabPage.UseVisualStyleBackColor = true;
            // 
            // securityTable
            // 
            securityTable.AutoSize = true;
            securityTable.ColumnCount = 1;
            securityTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            securityTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            securityTable.Controls.Add(localAccountsTable, 0, 1);
            securityTable.Controls.Add(localAdministratorsTable, 0, 3);
            securityTable.Controls.Add(localAccountsHeader, 0, 0);
            securityTable.Controls.Add(localAdministratorsHeader, 0, 2);
            securityTable.Controls.Add(installedHotFixesHeader, 0, 4);
            securityTable.Controls.Add(firewallRulesHeader, 0, 6);
            securityTable.Controls.Add(installedHotFixesTable, 0, 5);
            securityTable.Controls.Add(firewallRulesTable, 0, 7);
            securityTable.Dock = DockStyle.Fill;
            securityTable.Location = new Point(3, 3);
            securityTable.Name = "securityTable";
            securityTable.RowCount = 8;
            securityTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            securityTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            securityTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            securityTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            securityTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            securityTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            securityTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            securityTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            securityTable.Size = new Size(1388, 567);
            securityTable.TabIndex = 0;
            // 
            // localAccountsTable
            // 
            localAccountsTable.AutoSize = true;
            localAccountsTable.ColumnCount = 2;
            localAccountsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            localAccountsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            localAccountsTable.Dock = DockStyle.Fill;
            localAccountsTable.Location = new Point(3, 23);
            localAccountsTable.Name = "localAccountsTable";
            localAccountsTable.RowCount = 2;
            localAccountsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            localAccountsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            localAccountsTable.Size = new Size(1382, 115);
            localAccountsTable.TabIndex = 0;
            // 
            // localAdministratorsTable
            // 
            localAdministratorsTable.AutoSize = true;
            localAdministratorsTable.ColumnCount = 2;
            localAdministratorsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            localAdministratorsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            localAdministratorsTable.Dock = DockStyle.Fill;
            localAdministratorsTable.Location = new Point(3, 164);
            localAdministratorsTable.Name = "localAdministratorsTable";
            localAdministratorsTable.RowCount = 2;
            localAdministratorsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            localAdministratorsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            localAdministratorsTable.Size = new Size(1382, 115);
            localAdministratorsTable.TabIndex = 1;
            // 
            // localAccountsHeader
            // 
            localAccountsHeader.AutoSize = true;
            localAccountsHeader.Location = new Point(3, 0);
            localAccountsHeader.Name = "localAccountsHeader";
            localAccountsHeader.Size = new Size(120, 17);
            localAccountsHeader.TabIndex = 2;
            localAccountsHeader.Text = "Local Accounts";
            // 
            // localAdministratorsHeader
            // 
            localAdministratorsHeader.AutoSize = true;
            localAdministratorsHeader.Location = new Point(3, 141);
            localAdministratorsHeader.Name = "localAdministratorsHeader";
            localAdministratorsHeader.Size = new Size(168, 17);
            localAdministratorsHeader.TabIndex = 3;
            localAdministratorsHeader.Text = "Local Administrators";
            // 
            // installedHotFixesHeader
            // 
            installedHotFixesHeader.AutoSize = true;
            installedHotFixesHeader.Location = new Point(3, 282);
            installedHotFixesHeader.Name = "installedHotFixesHeader";
            installedHotFixesHeader.Size = new Size(160, 17);
            installedHotFixesHeader.TabIndex = 4;
            installedHotFixesHeader.Text = "Installed Hot Fixes";
            // 
            // firewallRulesHeader
            // 
            firewallRulesHeader.AutoSize = true;
            firewallRulesHeader.Location = new Point(3, 423);
            firewallRulesHeader.Name = "firewallRulesHeader";
            firewallRulesHeader.Size = new Size(120, 17);
            firewallRulesHeader.TabIndex = 5;
            firewallRulesHeader.Text = "Firewall Rules";
            // 
            // installedHotFixesTable
            // 
            installedHotFixesTable.AutoSize = true;
            installedHotFixesTable.ColumnCount = 2;
            installedHotFixesTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            installedHotFixesTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            installedHotFixesTable.Dock = DockStyle.Fill;
            installedHotFixesTable.Location = new Point(3, 305);
            installedHotFixesTable.Name = "installedHotFixesTable";
            installedHotFixesTable.RowCount = 2;
            installedHotFixesTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            installedHotFixesTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            installedHotFixesTable.Size = new Size(1382, 115);
            installedHotFixesTable.TabIndex = 6;
            // 
            // firewallRulesTable
            // 
            firewallRulesTable.AutoSize = true;
            firewallRulesTable.ColumnCount = 2;
            firewallRulesTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            firewallRulesTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            firewallRulesTable.Dock = DockStyle.Fill;
            firewallRulesTable.Location = new Point(3, 446);
            firewallRulesTable.Name = "firewallRulesTable";
            firewallRulesTable.RowCount = 2;
            firewallRulesTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            firewallRulesTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            firewallRulesTable.Size = new Size(1382, 118);
            firewallRulesTable.TabIndex = 7;
            // 
            // softwareTabPage
            // 
            softwareTabPage.Controls.Add(softwareDataView);
            softwareTabPage.Location = new Point(4, 26);
            softwareTabPage.Name = "softwareTabPage";
            softwareTabPage.Padding = new Padding(3);
            softwareTabPage.Size = new Size(1394, 571);
            softwareTabPage.TabIndex = 7;
            softwareTabPage.Text = "Software";
            softwareTabPage.UseVisualStyleBackColor = true;
            // 
            // softwareDataView
            // 
            softwareDataView.AllowUserToAddRows = false;
            softwareDataView.AllowUserToDeleteRows = false;
            softwareDataView.AllowUserToResizeColumns = false;
            softwareDataView.AllowUserToResizeRows = false;
            softwareDataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            softwareDataView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            softwareDataView.BackgroundColor = SystemColors.Control;
            softwareDataView.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            softwareDataView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(0, 0, 0, 5);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            softwareDataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            softwareDataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Cascadia Mono", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            softwareDataView.DefaultCellStyle = dataGridViewCellStyle2;
            softwareDataView.Dock = DockStyle.Fill;
            softwareDataView.EnableHeadersVisualStyles = false;
            softwareDataView.Location = new Point(3, 3);
            softwareDataView.Name = "softwareDataView";
            softwareDataView.ReadOnly = true;
            softwareDataView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            softwareDataView.RowHeadersVisible = false;
            softwareDataView.RowTemplate.Height = 25;
            softwareDataView.Size = new Size(1388, 565);
            softwareDataView.TabIndex = 0;
            // 
            // exitButton
            // 
            exitButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            exitButton.BackColor = SystemColors.Control;
            exitButton.DialogResult = DialogResult.Cancel;
            exitButton.Location = new Point(1529, 645);
            exitButton.Margin = new Padding(3, 3, 10, 5);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(98, 42);
            exitButton.TabIndex = 5;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;
            // 
            // installedSoftwareBindingSource
            // 
            installedSoftwareBindingSource.DataMember = "InstalledSoftware";
            installedSoftwareBindingSource.DataSource = softwareInformationBindingSource;
            // 
            // softwareInformationBindingSource
            // 
            softwareInformationBindingSource.DataSource = typeof(Models.WorkstationReport.Data.SoftwareInformation);
            // 
            // WorkstationReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton = exitButton;
            ClientSize = new Size(1637, 748);
            Controls.Add(mainTableLayoutPanel);
            Controls.Add(headingFlowLayoutPanel);
            Font = new Font("Cascadia Mono", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "WorkstationReportForm";
            ShowInTaskbar = false;
            Text = "WorkstationReportForm";
            headingFlowLayoutPanel.ResumeLayout(false);
            headingFlowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            mainTableLayoutPanel.ResumeLayout(false);
            mainTableLayoutPanel.PerformLayout();
            headerFlowLayoutPanel.ResumeLayout(false);
            headerFlowLayoutPanel.PerformLayout();
            navigationFlowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            mainTabControl.ResumeLayout(false);
            generalTabPage.ResumeLayout(false);
            generalTabPage.PerformLayout();
            generalTableLayoutPanel.ResumeLayout(false);
            generalTableLayoutPanel.PerformLayout();
            generalInformationFlowLayoutPanel.ResumeLayout(false);
            generalInformationFlowLayoutPanel.PerformLayout();
            screenTimeoutFlowLayoutPanel.ResumeLayout(false);
            screenTimeoutFlowLayoutPanel.PerformLayout();
            centricityFlowLayoutPanel.ResumeLayout(false);
            centricityFlowLayoutPanel.PerformLayout();
            buildInformationFlowLayoutPanel.ResumeLayout(false);
            buildInformationFlowLayoutPanel.PerformLayout();
            maintenanceTabPage.ResumeLayout(false);
            maintenanceTabPage.PerformLayout();
            maintenanceTableLayoutPanel.ResumeLayout(false);
            maintenanceTableLayoutPanel.PerformLayout();
            maintenanceConfigurationFlowLayoutPanel.ResumeLayout(false);
            maintenanceConfigurationFlowLayoutPanel.PerformLayout();
            powerManagementFlowLayoutPanel.ResumeLayout(false);
            powerManagementFlowLayoutPanel.PerformLayout();
            hardwareTabPage.ResumeLayout(false);
            hardwareTabPage.PerformLayout();
            hardwareTableLayoutPanel.ResumeLayout(false);
            hardwareTableLayoutPanel.PerformLayout();
            hardwareProcessorsTable.ResumeLayout(false);
            hardwareProcessorsTable.PerformLayout();
            systemInformationPanel.ResumeLayout(false);
            systemInformationPanel.PerformLayout();
            hardwareMemoryTable.ResumeLayout(false);
            hardwareMemoryTable.PerformLayout();
            hardwarePhysicalDisksTable.ResumeLayout(false);
            hardwarePhysicalDisksTable.PerformLayout();
            hardwareLogicalDisksTable.ResumeLayout(false);
            hardwareLogicalDisksTable.PerformLayout();
            hardwareVideoContollersTable.ResumeLayout(false);
            hardwareVideoContollersTable.PerformLayout();
            biosTabPage.ResumeLayout(false);
            biosTabPage.PerformLayout();
            biosTable.ResumeLayout(false);
            biosTable.PerformLayout();
            biosSettingsTable.ResumeLayout(false);
            biosSettingsTable.PerformLayout();
            networkTabPage.ResumeLayout(false);
            networkTabPage.PerformLayout();
            networkTable.ResumeLayout(false);
            networkTable.PerformLayout();
            printersTabPage.ResumeLayout(false);
            printerTable.ResumeLayout(false);
            printerTable.PerformLayout();
            installedPrinterTable.ResumeLayout(false);
            installedPrinterTable.PerformLayout();
            defaultPrinterTable.ResumeLayout(false);
            defaultPrinterTable.PerformLayout();
            securityTabPage.ResumeLayout(false);
            securityTabPage.PerformLayout();
            securityTable.ResumeLayout(false);
            securityTable.PerformLayout();
            softwareTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)softwareDataView).EndInit();
            ((System.ComponentModel.ISupportInitialize)installedSoftwareBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)softwareInformationBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel headingFlowLayoutPanel;
        private PictureBox pictureBox1;
        private Label workstationReportHeadingLabel;
        private TableLayoutPanel mainTableLayoutPanel;
        private FlowLayoutPanel headerFlowLayoutPanel;
        private Label ipAddressHeaderLabel;
        private Label imageVersionHeaderLabel;
        private Label imageModeHeaderLabel;
        private Label currentUserHeaderLabel;
        private FlowLayoutPanel navigationFlowLayoutPanel;
        private Button generalNavButton;
        private Button maintenanceNavButton;
        private Button hardwareNavButton;
        private Button biosNavButton;
        private Button networkNavButton;
        private Button printersNavButton;
        private Button securityNavButton;
        private Button softwareNavButton;
        private PictureBox pictureBox2;
        private TabControl mainTabControl;
        private TabPage generalTabPage;
        private TabPage maintenanceTabPage;
        private TabPage hardwareTabPage;
        private TabPage biosTabPage;
        private TabPage networkTabPage;
        private TabPage printersTabPage;
        private TabPage securityTabPage;
        private TabPage softwareTabPage;
        private Button exitButton;
        private Label deviceNameHeaderLabel;
        private TableLayoutPanel generalTableLayoutPanel;
        private FlowLayoutPanel generalInformationFlowLayoutPanel;
        private Label generalInformationHeaderLabel;
        private Label operatingSystemLabel;
        private Label imageVersionLabel;
        private Label imageModeLabel;
        private Label currentUserLabel;
        private FlowLayoutPanel screenTimeoutFlowLayoutPanel;
        private Label screenTimeoutHeaderLabel;
        private Label screenSaverTimeoutLabel;
        private Label screenLockTimeoutLabel;
        private Label autoLogoffTimeoutLabel;
        private FlowLayoutPanel centricityFlowLayoutPanel;
        private Label centricityHeaderLabel;
        private Label centricityTimerLabel;
        private Label centricityEnvironmentLabel;
        private FlowLayoutPanel buildInformationFlowLayoutPanel;
        private Label buildInformationHeaderLabel;
        private Label builtByLabel;
        private Label buildDateLabel;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private TableLayoutPanel maintenanceTableLayoutPanel;
        private FlowLayoutPanel maintenanceConfigurationFlowLayoutPanel;
        private Label maintenanceConfigurationLabel;
        private Label maintenanceTimeLabel;
        private Label lastBeganLabel;
        private Label lastCompletedLabel;
        private Label lastSucceededLabel;
        private Label lastResultLabel;
        private Label rebootPendingLabel;
        private Label machineUpTimeLabel;
        private FlowLayoutPanel powerManagementFlowLayoutPanel;
        private Label powerManagementHeaderLabel;
        private Label systemUnitManagementLabel;
        private TableLayoutPanel hardwareTableLayoutPanel;
        private FlowLayoutPanel systemInformationPanel;
        private Label systemInformationHeaderLabel;
        private Label modelLabel;
        private Label manufacturerLabel;
        private Label SMBIOSAssetTagLabel;
        private TableLayoutPanel hardwareProcessorsTable;
        private Label processorNameHeadingLabel;
        private Label processorTypeHeadingLabel;
        private Label architectureHeadingLabel;
        private Label cpuStatusHeadingLabel;
        private TableLayoutPanel hardwareMemoryTable;
        private Label memoryNameHeadingLabel;
        private Label memoryCapacityLabel;
        private Label memorySpeedLabel;
        private Label memoryTypeLabel;
        private Label memoryHeaderLabel;
        private TableLayoutPanel hardwarePhysicalDisksTable;
        private TableLayoutPanel hardwareLogicalDisksTable;
        private Label serialNumberLabel;
        private Label physicalDisksHeaderLabel;
        private Label hardDriveNameHeadingLabel;
        private Label hardDriveModelHeadingLabel;
        private Label hardDriveSizeHeadingLabel;
        private Label hardDriveTypeHeadingLabel;
        private Label hardDrivePartitionsHeadingLabel;
        private Label logicalDisksHeaderLabel;
        private Label diskDriveIdHeadingLabel;
        private Label diskDriveNameHeadingLabel;
        private Label diskDriveFileSystemHeadingLabel;
        private Label diskDriveDriveTypeHeadingLabel;
        private Label diskDriveMediaTypeHeadingLabel;
        private Label diskDriveFreeSpaceHeadingLabel;
        private Label diskDriveCapacityHeadingLabel;
        private TableLayoutPanel hardwareVideoContollersTable;
        private Label videoControllersHeaderLabel;
        private Label videoControllerBitsPerPixelHeadingLabel;
        private Label videoControllerDriverVersionHeadingLabel;
        private Label videoControllerDriverDateHeadingLabel;
        private Label videoControllerVideoProcessorHeadingLabel;
        private Label processorsHeaderLabel;
        private Label videoControllerNameHeadingLabel;
        private Label videoControllerRamHeadingLabel;
        private TableLayoutPanel biosTable;
        private Label biosInformationHeader;
        private FlowLayoutPanel biosInformationPanel;
        private Label bootOrderHeader;
        private FlowLayoutPanel bootOrderPanel;
        private Label biosSettingsHeader;
        private TableLayoutPanel networkTable;
        private Label networkAdaptersHeader;
        private Label ipConfigurationHeader;
        private TableLayoutPanel networkAdaptersTable;
        private TableLayoutPanel ipConfigurationTable;
        private TableLayoutPanel printerTable;
        private Label installedPrintersHeader;
        private Label printerDeafultHeader;
        private TableLayoutPanel installedPrinterTable;
        private TableLayoutPanel defaultPrinterTable;
        private TableLayoutPanel securityTable;
        private TableLayoutPanel localAccountsTable;
        private TableLayoutPanel localAdministratorsTable;
        private Label localAccountsHeader;
        private Label localAdministratorsHeader;
        private Label installedHotFixesHeader;
        private Label firewallRulesHeader;
        private TableLayoutPanel installedHotFixesTable;
        private TableLayoutPanel firewallRulesTable;
        private TableLayoutPanel biosSettingsTable;
        private Label biosAttributeName;
        private Label biosCurrentValue;
        private Label biosPossibleValues;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label loadingLabel;
        private DataGridView softwareData;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn publisherDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn installDateDataGridViewTextBoxColumn;
        private BindingSource installedSoftwareBindingSource;
        private BindingSource softwareInformationBindingSource;
        private DataGridView softwareDataView;
    }
}