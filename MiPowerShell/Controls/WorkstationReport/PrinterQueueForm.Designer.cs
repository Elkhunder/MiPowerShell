namespace MiPowerShell.Controls.WorkstationReport
{
    partial class PrinterQueueForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrinterQueueForm));
            mainPanel = new FlowLayoutPanel();
            headerPanel = new FlowLayoutPanel();
            icon = new PictureBox();
            headingLabel = new Label();
            mainTable = new TableLayoutPanel();
            queueStatusCard = new CardViewPanel();
            numberOfJobsCard = new CardViewPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            exitButton = new Button();
            purgeQueue = new Button();
            refreshPrinterQueues = new Button();
            resumeQueue = new Button();
            pauseQueue = new Button();
            restartSpooler = new Button();
            queuePortCard = new CardViewPanel();
            printQueuePanel = new PrintQueuePanel();
            spoolStatusCard = new CardViewPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            mainPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon).BeginInit();
            mainTable.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.AutoSize = true;
            mainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainPanel.Controls.Add(headerPanel);
            mainPanel.Controls.Add(mainTable);
            mainPanel.Controls.Add(flowLayoutPanel2);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.FlowDirection = FlowDirection.TopDown;
            mainPanel.Location = new Point(15, 15);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(860, 612);
            mainPanel.TabIndex = 2;
            // 
            // headerPanel
            // 
            headerPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            headerPanel.Controls.Add(icon);
            headerPanel.Controls.Add(headingLabel);
            headerPanel.Location = new Point(3, 3);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(855, 30);
            headerPanel.TabIndex = 0;
            // 
            // icon
            // 
            icon.Image = (Image)resources.GetObject("icon.Image");
            icon.Location = new Point(3, 3);
            icon.Name = "icon";
            icon.Size = new Size(24, 24);
            icon.SizeMode = PictureBoxSizeMode.AutoSize;
            icon.TabIndex = 0;
            icon.TabStop = false;
            // 
            // headingLabel
            // 
            headingLabel.Anchor = AnchorStyles.Right;
            headingLabel.AutoSize = true;
            headingLabel.Font = new Font("Cascadia Mono", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            headingLabel.Location = new Point(330, 5);
            headingLabel.Margin = new Padding(300, 0, 3, 0);
            headingLabel.Name = "headingLabel";
            headingLabel.Size = new Size(126, 20);
            headingLabel.TabIndex = 3;
            headingLabel.Text = "Printer Queue";
            // 
            // mainTable
            // 
            mainTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainTable.ColumnCount = 9;
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.9970818F));
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.9970837F));
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.0020866F));
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.00375F));
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            mainTable.Controls.Add(queueStatusCard, 3, 0);
            mainTable.Controls.Add(numberOfJobsCard, 5, 0);
            mainTable.Controls.Add(flowLayoutPanel1, 1, 2);
            mainTable.Controls.Add(queuePortCard, 7, 0);
            mainTable.Controls.Add(printQueuePanel, 1, 1);
            mainTable.Controls.Add(spoolStatusCard, 1, 0);
            mainTable.Location = new Point(3, 39);
            mainTable.Name = "mainTable";
            mainTable.RowCount = 3;
            mainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 122F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 378F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            mainTable.Size = new Size(855, 570);
            mainTable.TabIndex = 1;
            // 
            // queueStatusCard
            // 
            queueStatusCard.AutoSize = true;
            queueStatusCard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            queueStatusCard.BorderStyle = BorderStyle.FixedSingle;
            queueStatusCard.CardHeaderHeight = 25;
            queueStatusCard.CardHeaderSizeType = SizeType.Absolute;
            queueStatusCard.CardTitle = "Queue Status";
            queueStatusCard.CardTitleTextSize = 9;
            queueStatusCard.CardTitleTextStyle = FontStyle.Regular;
            queueStatusCard.CardValue = "Value";
            queueStatusCard.CardValueTextSize = 10;
            queueStatusCard.CardValueTextStyle = FontStyle.Bold;
            queueStatusCard.Dock = DockStyle.Fill;
            queueStatusCard.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point);
            queueStatusCard.Location = new Point(224, 3);
            queueStatusCard.Name = "queueStatusCard";
            queueStatusCard.Size = new Size(195, 116);
            queueStatusCard.TabIndex = 0;
            // 
            // numberOfJobsCard
            // 
            numberOfJobsCard.AutoSize = true;
            numberOfJobsCard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            numberOfJobsCard.BorderStyle = BorderStyle.FixedSingle;
            numberOfJobsCard.CardHeaderHeight = 25;
            numberOfJobsCard.CardHeaderSizeType = SizeType.Absolute;
            numberOfJobsCard.CardTitle = "Number of Jobs";
            numberOfJobsCard.CardTitleTextSize = 9;
            numberOfJobsCard.CardTitleTextStyle = FontStyle.Regular;
            numberOfJobsCard.CardValue = "Value";
            numberOfJobsCard.CardValueTextSize = 10;
            numberOfJobsCard.CardValueTextStyle = FontStyle.Bold;
            numberOfJobsCard.Dock = DockStyle.Fill;
            numberOfJobsCard.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point);
            numberOfJobsCard.Location = new Point(435, 3);
            numberOfJobsCard.Name = "numberOfJobsCard";
            numberOfJobsCard.Size = new Size(195, 116);
            numberOfJobsCard.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainTable.SetColumnSpan(flowLayoutPanel1, 7);
            flowLayoutPanel1.Controls.Add(exitButton);
            flowLayoutPanel1.Controls.Add(purgeQueue);
            flowLayoutPanel1.Controls.Add(refreshPrinterQueues);
            flowLayoutPanel1.Controls.Add(resumeQueue);
            flowLayoutPanel1.Controls.Add(pauseQueue);
            flowLayoutPanel1.Controls.Add(restartSpooler);
            flowLayoutPanel1.Cursor = Cursors.Hand;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(10, 500);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(834, 70);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // exitButton
            // 
            exitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            exitButton.AutoSize = true;
            exitButton.DialogResult = DialogResult.Cancel;
            exitButton.Location = new Point(756, 3);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(75, 30);
            exitButton.TabIndex = 1;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // purgeQueue
            // 
            purgeQueue.AutoSize = true;
            purgeQueue.Dock = DockStyle.Fill;
            purgeQueue.Location = new Point(649, 3);
            purgeQueue.Name = "purgeQueue";
            purgeQueue.Size = new Size(101, 30);
            purgeQueue.TabIndex = 2;
            purgeQueue.Text = "Purge Queue";
            purgeQueue.UseVisualStyleBackColor = true;
            purgeQueue.Click += purgePrinterQueues_Click;
            // 
            // refreshPrinterQueues
            // 
            refreshPrinterQueues.AutoSize = true;
            refreshPrinterQueues.Dock = DockStyle.Fill;
            refreshPrinterQueues.Location = new Point(528, 3);
            refreshPrinterQueues.Name = "refreshPrinterQueues";
            refreshPrinterQueues.Size = new Size(115, 30);
            refreshPrinterQueues.TabIndex = 3;
            refreshPrinterQueues.Text = "Refresh Queue";
            refreshPrinterQueues.UseVisualStyleBackColor = true;
            refreshPrinterQueues.Click += refreshPrinterQueues_Click;
            // 
            // resumeQueue
            // 
            resumeQueue.AutoSize = true;
            resumeQueue.Dock = DockStyle.Fill;
            resumeQueue.Location = new Point(414, 3);
            resumeQueue.Name = "resumeQueue";
            resumeQueue.Size = new Size(108, 30);
            resumeQueue.TabIndex = 4;
            resumeQueue.Text = "Resume Queue";
            resumeQueue.UseVisualStyleBackColor = true;
            resumeQueue.Click += resumePrinterQueues_Click;
            // 
            // pauseQueue
            // 
            pauseQueue.AutoSize = true;
            pauseQueue.Dock = DockStyle.Fill;
            pauseQueue.Location = new Point(307, 3);
            pauseQueue.Name = "pauseQueue";
            pauseQueue.Size = new Size(101, 30);
            pauseQueue.TabIndex = 5;
            pauseQueue.Text = "Pause Queue";
            pauseQueue.UseVisualStyleBackColor = true;
            pauseQueue.Click += pausePrinterQueues_Click;
            // 
            // restartSpooler
            // 
            restartSpooler.AutoSize = true;
            restartSpooler.Location = new Point(2, 3);
            restartSpooler.Margin = new Padding(0, 3, 180, 3);
            restartSpooler.Name = "restartSpooler";
            restartSpooler.Size = new Size(122, 30);
            restartSpooler.TabIndex = 6;
            restartSpooler.Text = "Restart Spooler";
            restartSpooler.UseVisualStyleBackColor = true;
            restartSpooler.Click += restartSpooler_Click;
            // 
            // queuePortCard
            // 
            queuePortCard.AutoSize = true;
            queuePortCard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            queuePortCard.BorderStyle = BorderStyle.FixedSingle;
            queuePortCard.CardHeaderHeight = 25;
            queuePortCard.CardHeaderSizeType = SizeType.Absolute;
            queuePortCard.CardTitle = "Queue Port";
            queuePortCard.CardTitleTextSize = 9;
            queuePortCard.CardTitleTextStyle = FontStyle.Regular;
            queuePortCard.CardValue = "Value";
            queuePortCard.CardValueTextSize = 10;
            queuePortCard.CardValueTextStyle = FontStyle.Bold;
            queuePortCard.Cursor = Cursors.Hand;
            queuePortCard.Dock = DockStyle.Fill;
            queuePortCard.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point);
            queuePortCard.Location = new Point(646, 3);
            queuePortCard.Name = "queuePortCard";
            queuePortCard.Size = new Size(195, 116);
            queuePortCard.TabIndex = 3;
            queuePortCard.Click += queuePortCard_Click;
            // 
            // printQueuePanel
            // 
            printQueuePanel.AutoSize = true;
            printQueuePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            printQueuePanel.BorderStyle = BorderStyle.FixedSingle;
            mainTable.SetColumnSpan(printQueuePanel, 7);
            printQueuePanel.Dock = DockStyle.Fill;
            printQueuePanel.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point);
            printQueuePanel.Location = new Point(13, 125);
            printQueuePanel.Name = "printQueuePanel";
            printQueuePanel.PrintQueue = null;
            printQueuePanel.PrintQueueForm = null;
            printQueuePanel.Size = new Size(828, 372);
            printQueuePanel.TabIndex = 5;
            // 
            // spoolStatusCard
            // 
            spoolStatusCard.AutoSize = true;
            spoolStatusCard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            spoolStatusCard.BorderStyle = BorderStyle.FixedSingle;
            spoolStatusCard.CardHeaderHeight = 25;
            spoolStatusCard.CardHeaderSizeType = SizeType.Absolute;
            spoolStatusCard.CardTitle = "Spooler Status";
            spoolStatusCard.CardTitleTextSize = 9;
            spoolStatusCard.CardTitleTextStyle = FontStyle.Regular;
            spoolStatusCard.CardValue = "Value";
            spoolStatusCard.CardValueTextSize = 10;
            spoolStatusCard.CardValueTextStyle = FontStyle.Bold;
            spoolStatusCard.Dock = DockStyle.Fill;
            spoolStatusCard.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point);
            spoolStatusCard.Location = new Point(13, 3);
            spoolStatusCard.Name = "spoolStatusCard";
            spoolStatusCard.Size = new Size(195, 116);
            spoolStatusCard.TabIndex = 6;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Location = new Point(864, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(0, 0);
            flowLayoutPanel2.TabIndex = 3;
            // 
            // PrinterQueueForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(890, 642);
            Controls.Add(mainPanel);
            Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PrinterQueueForm";
            Padding = new Padding(15);
            StartPosition = FormStartPosition.CenterParent;
            Text = "PrinterQueueForm";
            TopMost = true;
            FormClosed += PrinterQueueForm_FormClosed;
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icon).EndInit();
            mainTable.ResumeLayout(false);
            mainTable.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel mainPanel;
        private FlowLayoutPanel headerPanel;
        private PictureBox icon;
        private Label headingLabel;
        private TableLayoutPanel mainTable;
        private Button exitButton;
        private CardViewPanel cardViewPanel1;
        private CardViewPanel cardViewPanel2;
        private CardViewPanel cardViewPanel3;
        private CardViewPanel cardViewPanel4;
        private CardViewPanel cardViewPanel5;
        private PrintQueuePanel printQueuePanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button purgeQueue;
        private Button refreshPrinterQueues;
        private Button resumeQueue;
        private Button pauseQueue;
        private CardViewPanel queueStatusCard;
        private CardViewPanel numberOfJobsCard;
        private CardViewPanel queuePortCard;
        private PrintQueuePanel printQueuePanel;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button restartSpooler;
        private CardViewPanel spoolStatusCard;
    }
}