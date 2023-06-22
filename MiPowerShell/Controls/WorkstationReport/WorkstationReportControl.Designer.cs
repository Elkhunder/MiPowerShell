namespace MiPowerShell.Controls.WorkstationReport
{
    partial class WorkstationReportControl
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
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            generalInformationBindingSource = new BindingSource(components);
            generalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            locationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            centricityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            screenTimeOutsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            buildInformationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)generalInformationBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { generalDataGridViewTextBoxColumn, locationDataGridViewTextBoxColumn, centricityDataGridViewTextBoxColumn, screenTimeOutsDataGridViewTextBoxColumn, buildInformationDataGridViewTextBoxColumn });
            dataGridView1.DataSource = generalInformationBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(548, 356);
            dataGridView1.TabIndex = 0;
            // 
            // generalInformationBindingSource
            // 
            generalInformationBindingSource.DataSource = typeof(Models.WorkstationReport.GeneralInformation);
            // 
            // generalDataGridViewTextBoxColumn
            // 
            generalDataGridViewTextBoxColumn.DataPropertyName = "General";
            generalDataGridViewTextBoxColumn.HeaderText = "General";
            generalDataGridViewTextBoxColumn.Name = "generalDataGridViewTextBoxColumn";
            // 
            // locationDataGridViewTextBoxColumn
            // 
            locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            locationDataGridViewTextBoxColumn.HeaderText = "Location";
            locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            // 
            // centricityDataGridViewTextBoxColumn
            // 
            centricityDataGridViewTextBoxColumn.DataPropertyName = "Centricity";
            centricityDataGridViewTextBoxColumn.HeaderText = "Centricity";
            centricityDataGridViewTextBoxColumn.Name = "centricityDataGridViewTextBoxColumn";
            // 
            // screenTimeOutsDataGridViewTextBoxColumn
            // 
            screenTimeOutsDataGridViewTextBoxColumn.DataPropertyName = "ScreenTimeOuts";
            screenTimeOutsDataGridViewTextBoxColumn.HeaderText = "ScreenTimeOuts";
            screenTimeOutsDataGridViewTextBoxColumn.Name = "screenTimeOutsDataGridViewTextBoxColumn";
            // 
            // buildInformationDataGridViewTextBoxColumn
            // 
            buildInformationDataGridViewTextBoxColumn.DataPropertyName = "BuildInformation";
            buildInformationDataGridViewTextBoxColumn.HeaderText = "BuildInformation";
            buildInformationDataGridViewTextBoxColumn.Name = "buildInformationDataGridViewTextBoxColumn";
            // 
            // WorkstationReportControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Name = "WorkstationReportControl";
            Size = new Size(548, 356);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)generalInformationBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn generalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn centricityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn screenTimeOutsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn buildInformationDataGridViewTextBoxColumn;
        private BindingSource generalInformationBindingSource;
    }
}
