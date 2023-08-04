namespace MiPowerShell.Controls.WorkstationReport
{
    partial class CardViewPanel
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
            mainTablePanel = new TableLayoutPanel();
            headerLabel = new Label();
            valueLabel = new Label();
            mainTablePanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainTablePanel
            // 
            mainTablePanel.AutoSize = true;
            mainTablePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainTablePanel.ColumnCount = 1;
            mainTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTablePanel.Controls.Add(headerLabel, 0, 0);
            mainTablePanel.Controls.Add(valueLabel, 0, 1);
            mainTablePanel.Dock = DockStyle.Fill;
            mainTablePanel.ImeMode = ImeMode.NoControl;
            mainTablePanel.Location = new Point(0, 0);
            mainTablePanel.Name = "mainTablePanel";
            mainTablePanel.RowCount = 2;
            mainTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.3767719F));
            mainTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 83.62323F));
            mainTablePanel.Size = new Size(128, 110);
            mainTablePanel.TabIndex = 0;
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.BackColor = SystemColors.ControlDark;
            headerLabel.Dock = DockStyle.Fill;
            headerLabel.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            headerLabel.Location = new Point(0, 0);
            headerLabel.Margin = new Padding(0);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(128, 18);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "# of Print Jobs";
            headerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // valueLabel
            // 
            valueLabel.AutoSize = true;
            valueLabel.Dock = DockStyle.Fill;
            valueLabel.Font = new Font("Cascadia Mono", 10F, FontStyle.Regular, GraphicsUnit.Point);
            valueLabel.Location = new Point(3, 21);
            valueLabel.Margin = new Padding(3);
            valueLabel.Name = "valueLabel";
            valueLabel.Size = new Size(122, 86);
            valueLabel.TabIndex = 1;
            valueLabel.Text = "0";
            valueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CardViewPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(mainTablePanel);
            Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "CardViewPanel";
            Size = new Size(128, 110);
            mainTablePanel.ResumeLayout(false);
            mainTablePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel mainTablePanel;
        private Label headerLabel;
        private Label valueLabel;
    }
}
