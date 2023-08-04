namespace MiPowerShell.Controls.WorkstationReport
{
    partial class PrintQueuePanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainTable = new TableLayoutPanel();
            printJobTable = new TableLayoutPanel();
            printJobPages = new Label();
            printJobStatus = new Label();
            printJobSubmitter = new Label();
            printJobName = new Label();
            printJobIdentifier = new Label();
            label1 = new Label();
            headingLabel = new Label();
            mainTable.SuspendLayout();
            printJobTable.SuspendLayout();
            SuspendLayout();
            // 
            // mainTable
            // 
            mainTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainTable.ColumnCount = 1;
            mainTable.ColumnStyles.Add(new ColumnStyle());
            mainTable.Controls.Add(printJobTable, 0, 1);
            mainTable.Controls.Add(headingLabel, 0, 0);
            mainTable.Dock = DockStyle.Fill;
            mainTable.Location = new Point(0, 0);
            mainTable.Name = "mainTable";
            mainTable.RowCount = 2;
            mainTable.RowStyles.Add(new RowStyle());
            mainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            mainTable.Size = new Size(831, 338);
            mainTable.TabIndex = 0;
            // 
            // printJobTable
            // 
            printJobTable.AutoScroll = true;
            printJobTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            printJobTable.ColumnCount = 7;
            printJobTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            printJobTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            printJobTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            printJobTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
            printJobTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 104F));
            printJobTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            printJobTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            printJobTable.Controls.Add(printJobPages, 4, 0);
            printJobTable.Controls.Add(printJobStatus, 3, 0);
            printJobTable.Controls.Add(printJobSubmitter, 2, 0);
            printJobTable.Controls.Add(printJobName, 1, 0);
            printJobTable.Controls.Add(printJobIdentifier, 0, 0);
            printJobTable.Controls.Add(label1, 5, 0);
            printJobTable.Dock = DockStyle.Fill;
            printJobTable.Location = new Point(0, 40);
            printJobTable.Margin = new Padding(0);
            printJobTable.Name = "printJobTable";
            printJobTable.RowCount = 1;
            printJobTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            printJobTable.Size = new Size(831, 298);
            printJobTable.TabIndex = 13;
            // 
            // printJobPages
            // 
            printJobPages.AutoSize = true;
            printJobPages.BackColor = SystemColors.ControlDark;
            printJobPages.Dock = DockStyle.Fill;
            printJobPages.Font = new Font("Cascadia Mono", 10F, FontStyle.Bold, GraphicsUnit.Point);
            printJobPages.Location = new Point(530, 0);
            printJobPages.Margin = new Padding(0);
            printJobPages.Name = "printJobPages";
            printJobPages.Padding = new Padding(0, 5, 0, 5);
            printJobPages.Size = new Size(104, 298);
            printJobPages.TabIndex = 8;
            printJobPages.Text = "Pages";
            printJobPages.TextAlign = ContentAlignment.TopCenter;
            // 
            // printJobStatus
            // 
            printJobStatus.AutoSize = true;
            printJobStatus.BackColor = SystemColors.ControlDark;
            printJobStatus.Dock = DockStyle.Fill;
            printJobStatus.Font = new Font("Cascadia Mono", 10F, FontStyle.Bold, GraphicsUnit.Point);
            printJobStatus.Location = new Point(360, 0);
            printJobStatus.Margin = new Padding(0);
            printJobStatus.Name = "printJobStatus";
            printJobStatus.Padding = new Padding(0, 5, 0, 5);
            printJobStatus.Size = new Size(170, 298);
            printJobStatus.TabIndex = 7;
            printJobStatus.Text = "Status";
            printJobStatus.TextAlign = ContentAlignment.TopCenter;
            // 
            // printJobSubmitter
            // 
            printJobSubmitter.AutoSize = true;
            printJobSubmitter.BackColor = SystemColors.ControlDark;
            printJobSubmitter.Dock = DockStyle.Fill;
            printJobSubmitter.Font = new Font("Cascadia Mono", 10F, FontStyle.Bold, GraphicsUnit.Point);
            printJobSubmitter.Location = new Point(220, 0);
            printJobSubmitter.Margin = new Padding(0);
            printJobSubmitter.Name = "printJobSubmitter";
            printJobSubmitter.Padding = new Padding(0, 5, 0, 5);
            printJobSubmitter.Size = new Size(140, 298);
            printJobSubmitter.TabIndex = 2;
            printJobSubmitter.Text = "Submitter";
            printJobSubmitter.TextAlign = ContentAlignment.TopCenter;
            // 
            // printJobName
            // 
            printJobName.AutoSize = true;
            printJobName.BackColor = SystemColors.ControlDark;
            printJobName.Dock = DockStyle.Fill;
            printJobName.Font = new Font("Cascadia Mono", 10F, FontStyle.Bold, GraphicsUnit.Point);
            printJobName.Location = new Point(80, 0);
            printJobName.Margin = new Padding(0);
            printJobName.Name = "printJobName";
            printJobName.Padding = new Padding(0, 5, 0, 5);
            printJobName.Size = new Size(140, 298);
            printJobName.TabIndex = 1;
            printJobName.Text = "Name";
            printJobName.TextAlign = ContentAlignment.TopCenter;
            // 
            // printJobIdentifier
            // 
            printJobIdentifier.AutoSize = true;
            printJobIdentifier.BackColor = SystemColors.ControlDark;
            printJobIdentifier.Dock = DockStyle.Fill;
            printJobIdentifier.Font = new Font("Cascadia Mono", 10F, FontStyle.Bold, GraphicsUnit.Point);
            printJobIdentifier.Location = new Point(0, 0);
            printJobIdentifier.Margin = new Padding(0);
            printJobIdentifier.Name = "printJobIdentifier";
            printJobIdentifier.Padding = new Padding(0, 5, 0, 5);
            printJobIdentifier.Size = new Size(80, 298);
            printJobIdentifier.TabIndex = 0;
            printJobIdentifier.Text = "ID";
            printJobIdentifier.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlDark;
            printJobTable.SetColumnSpan(label1, 2);
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(634, 0);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(197, 298);
            label1.TabIndex = 9;
            // 
            // headingLabel
            // 
            headingLabel.AutoSize = true;
            headingLabel.Dock = DockStyle.Fill;
            headingLabel.Font = new Font("Cascadia Mono", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            headingLabel.Location = new Point(3, 0);
            headingLabel.Name = "headingLabel";
            headingLabel.Padding = new Padding(0, 10, 0, 10);
            headingLabel.Size = new Size(825, 40);
            headingLabel.TabIndex = 11;
            headingLabel.Text = "Print Jobs";
            headingLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // PrintQueuePanel
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainTable);
            Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "PrintQueuePanel";
            Size = new Size(831, 338);
            mainTable.ResumeLayout(false);
            mainTable.PerformLayout();
            printJobTable.ResumeLayout(false);
            printJobTable.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel printJobTable;
        private Label headingLabel;
        private TableLayoutPanel printJobPanel;
        private Label printJobPages;
        private Label printJobStatus;
        private Label printJobSubmitter;
        private Label printJobName;
        private Label printJobIdentifier;
        private TableLayoutPanel mainTable;
        private Label label1;
    }
}
