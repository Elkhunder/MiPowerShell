namespace MiPowerShell
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            ListBox_Commands = new ListBox();
            activeCommandsBindingSource = new BindingSource(components);
            commandsBindingSource = new BindingSource(components);
            Label_Commands_Heading = new Label();
            label_Command_Heading = new Label();
            Button_Command_Clear = new Button();
            Button_Command_Cancel = new Button();
            Button_Command_Execute = new Button();
            helpProvider1 = new HelpProvider();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            TableLayoutPanel_CommandButtons = new TableLayoutPanel();
            Button_Local = new Button();
            Button_Remote = new Button();
            Button_File = new Button();
            TableLayoutPanel_Input = new TableLayoutPanel();
            commandArgumentsBindingSource = new BindingSource(components);
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)activeCommandsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)commandsBindingSource).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            TableLayoutPanel_CommandButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)commandArgumentsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // ListBox_Commands
            // 
            ListBox_Commands.Dock = DockStyle.Fill;
            ListBox_Commands.FormattingEnabled = true;
            ListBox_Commands.ItemHeight = 18;
            ListBox_Commands.Location = new Point(3, 27);
            ListBox_Commands.Margin = new Padding(3, 2, 3, 2);
            ListBox_Commands.Name = "ListBox_Commands";
            tableLayoutPanel1.SetRowSpan(ListBox_Commands, 2);
            ListBox_Commands.Size = new Size(190, 304);
            ListBox_Commands.Sorted = true;
            ListBox_Commands.TabIndex = 1;
            ListBox_Commands.Tag = "Commands";
            ListBox_Commands.SelectedIndexChanged += ListBox_Commands_SelectedIndexChanged;
            // 
            // activeCommandsBindingSource
            // 
            activeCommandsBindingSource.DataMember = "ActiveCommands";
            activeCommandsBindingSource.DataSource = commandsBindingSource;
            // 
            // commandsBindingSource
            // 
            commandsBindingSource.DataSource = typeof(Models.Commands);
            // 
            // Label_Commands_Heading
            // 
            Label_Commands_Heading.AutoSize = true;
            Label_Commands_Heading.Dock = DockStyle.Fill;
            Label_Commands_Heading.Location = new Point(3, 0);
            Label_Commands_Heading.Name = "Label_Commands_Heading";
            Label_Commands_Heading.Size = new Size(190, 25);
            Label_Commands_Heading.TabIndex = 0;
            Label_Commands_Heading.Text = "Command Selector";
            Label_Commands_Heading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Command_Heading
            // 
            label_Command_Heading.AutoSize = true;
            label_Command_Heading.Dock = DockStyle.Fill;
            label_Command_Heading.Location = new Point(199, 0);
            label_Command_Heading.Name = "label_Command_Heading";
            label_Command_Heading.Size = new Size(330, 25);
            label_Command_Heading.TabIndex = 2;
            label_Command_Heading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Button_Command_Clear
            // 
            Button_Command_Clear.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Button_Command_Clear.Dock = DockStyle.Top;
            Button_Command_Clear.FlatStyle = FlatStyle.Popup;
            Button_Command_Clear.Location = new Point(113, 3);
            Button_Command_Clear.MaximumSize = new Size(99, 32);
            Button_Command_Clear.Name = "Button_Command_Clear";
            Button_Command_Clear.Size = new Size(99, 32);
            Button_Command_Clear.TabIndex = 7;
            Button_Command_Clear.Text = "Clear";
            Button_Command_Clear.UseVisualStyleBackColor = true;
            Button_Command_Clear.Click += Button_Command_Clear_Click;
            Button_Command_Clear.MouseLeave += Button_Command_Clear_MouseLeave;
            // 
            // Button_Command_Cancel
            // 
            Button_Command_Cancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Button_Command_Cancel.DialogResult = DialogResult.Cancel;
            Button_Command_Cancel.Dock = DockStyle.Top;
            Button_Command_Cancel.FlatStyle = FlatStyle.Popup;
            Button_Command_Cancel.Location = new Point(223, 3);
            Button_Command_Cancel.MaximumSize = new Size(99, 32);
            Button_Command_Cancel.Name = "Button_Command_Cancel";
            Button_Command_Cancel.Size = new Size(99, 32);
            Button_Command_Cancel.TabIndex = 8;
            Button_Command_Cancel.Text = "Exit";
            Button_Command_Cancel.UseVisualStyleBackColor = true;
            Button_Command_Cancel.Click += Button_Command_Cancel_Click;
            Button_Command_Cancel.MouseHover += Button_Command_Cancel_MouseHover;
            // 
            // Button_Command_Execute
            // 
            Button_Command_Execute.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Button_Command_Execute.DialogResult = DialogResult.OK;
            Button_Command_Execute.Dock = DockStyle.Top;
            Button_Command_Execute.FlatAppearance.MouseOverBackColor = SystemColors.ButtonShadow;
            Button_Command_Execute.FlatStyle = FlatStyle.Popup;
            Button_Command_Execute.Location = new Point(3, 3);
            Button_Command_Execute.MaximumSize = new Size(99, 32);
            Button_Command_Execute.Name = "Button_Command_Execute";
            Button_Command_Execute.Size = new Size(99, 32);
            Button_Command_Execute.TabIndex = 6;
            Button_Command_Execute.Text = "Execute";
            Button_Command_Execute.UseVisualStyleBackColor = true;
            Button_Command_Execute.Click += Button_Command_Execute_Click;
            Button_Command_Execute.MouseHover += Button_Command_Execute_MouseHover;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(label_Command_Heading, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 3);
            tableLayoutPanel1.Controls.Add(Label_Commands_Heading, 0, 0);
            tableLayoutPanel1.Controls.Add(ListBox_Commands, 0, 1);
            tableLayoutPanel1.Controls.Add(TableLayoutPanel_CommandButtons, 1, 1);
            tableLayoutPanel1.Controls.Add(TableLayoutPanel_Input, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(532, 379);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel2.Controls.Add(Button_Command_Cancel, 2, 0);
            tableLayoutPanel2.Controls.Add(Button_Command_Clear, 1, 0);
            tableLayoutPanel2.Controls.Add(Button_Command_Execute, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(199, 336);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(330, 40);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // TableLayoutPanel_CommandButtons
            // 
            TableLayoutPanel_CommandButtons.AutoSize = true;
            TableLayoutPanel_CommandButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TableLayoutPanel_CommandButtons.ColumnCount = 3;
            TableLayoutPanel_CommandButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.57734F));
            TableLayoutPanel_CommandButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.57733F));
            TableLayoutPanel_CommandButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40.84533F));
            TableLayoutPanel_CommandButtons.Controls.Add(Button_Local, 0, 0);
            TableLayoutPanel_CommandButtons.Controls.Add(Button_Remote, 1, 0);
            TableLayoutPanel_CommandButtons.Controls.Add(Button_File, 2, 0);
            TableLayoutPanel_CommandButtons.Dock = DockStyle.Fill;
            TableLayoutPanel_CommandButtons.Location = new Point(199, 28);
            TableLayoutPanel_CommandButtons.Name = "TableLayoutPanel_CommandButtons";
            TableLayoutPanel_CommandButtons.RowCount = 1;
            TableLayoutPanel_CommandButtons.RowStyles.Add(new RowStyle());
            TableLayoutPanel_CommandButtons.Size = new Size(330, 34);
            TableLayoutPanel_CommandButtons.TabIndex = 4;
            // 
            // Button_Local
            // 
            Button_Local.AutoSize = true;
            Button_Local.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Button_Local.Dock = DockStyle.Fill;
            Button_Local.FlatStyle = FlatStyle.Popup;
            Button_Local.Location = new Point(3, 3);
            Button_Local.Name = "Button_Local";
            Button_Local.Size = new Size(91, 28);
            Button_Local.TabIndex = 0;
            Button_Local.Text = "Local";
            Button_Local.UseVisualStyleBackColor = true;
            Button_Local.Click += Button_Local_Click;
            Button_Local.MouseHover += Button_Local_MouseHover;
            // 
            // Button_Remote
            // 
            Button_Remote.AutoSize = true;
            Button_Remote.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Button_Remote.Dock = DockStyle.Fill;
            Button_Remote.FlatStyle = FlatStyle.Popup;
            Button_Remote.Location = new Point(100, 3);
            Button_Remote.Name = "Button_Remote";
            Button_Remote.Size = new Size(91, 28);
            Button_Remote.TabIndex = 1;
            Button_Remote.Text = "Remote";
            Button_Remote.UseVisualStyleBackColor = true;
            Button_Remote.Click += Button_Remote_Click;
            Button_Remote.MouseHover += Button_Remote_MouseHover;
            // 
            // Button_File
            // 
            Button_File.AutoSize = true;
            Button_File.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Button_File.Dock = DockStyle.Fill;
            Button_File.FlatStyle = FlatStyle.Popup;
            Button_File.Location = new Point(197, 3);
            Button_File.Name = "Button_File";
            Button_File.Size = new Size(130, 28);
            Button_File.TabIndex = 2;
            Button_File.Text = "Select File";
            Button_File.UseVisualStyleBackColor = true;
            Button_File.Click += Button_File_Click;
            Button_File.MouseHover += Button_File_MouseHover;
            // 
            // TableLayoutPanel_Input
            // 
            TableLayoutPanel_Input.ColumnCount = 1;
            TableLayoutPanel_Input.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TableLayoutPanel_Input.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            TableLayoutPanel_Input.Dock = DockStyle.Fill;
            TableLayoutPanel_Input.Location = new Point(199, 68);
            TableLayoutPanel_Input.Name = "TableLayoutPanel_Input";
            TableLayoutPanel_Input.RowCount = 2;
            TableLayoutPanel_Input.RowStyles.Add(new RowStyle());
            TableLayoutPanel_Input.RowStyles.Add(new RowStyle());
            TableLayoutPanel_Input.Size = new Size(330, 262);
            TableLayoutPanel_Input.TabIndex = 5;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(0, 379);
            dataGridView1.Margin = new Padding(20, 3, 20, 3);
            dataGridView1.MaximumSize = new Size(514, 1080);
            dataGridView1.MinimumSize = new Size(514, 6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(514, 83);
            dataGridView1.TabIndex = 12;
            dataGridView1.TabStop = false;
            // 
            // Form1
            // 
            AcceptButton = Button_Command_Execute;
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            CancelButton = Button_Command_Cancel;
            ClientSize = new Size(532, 462);
            Controls.Add(dataGridView1);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(1920, 1080);
            MinimumSize = new Size(530, 424);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiPowerShell";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)activeCommandsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)commandsBindingSource).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            TableLayoutPanel_CommandButtons.ResumeLayout(false);
            TableLayoutPanel_CommandButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)commandArgumentsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox ListBox_Commands;
        private Label Label_Commands_Heading;
        private Label label_Command_Heading;
        private Button Button_Command_Clear;
        private Button Button_Command_Cancel;
        private Button Button_Command_Execute;
        private HelpProvider helpProvider1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel TableLayoutPanel_CommandButtons;
        private Button Button_Local;
        private Button Button_Remote;
        private Button Button_File;
        private TableLayoutPanel TableLayoutPanel_Input;
        private BindingSource commandArgumentsBindingSource;
        private DataGridView dataGridView1;
        private BindingSource commandsBindingSource;
        private BindingSource activeCommandsBindingSource;
    }
}