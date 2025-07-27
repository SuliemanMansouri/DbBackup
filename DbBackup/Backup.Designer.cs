namespace BbBackup
{
    partial class Backup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Backup));
            BackpButton = new Button();
            UseRemovalbleDriveCheckBox = new CheckBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            UseScheduleCheckBox = new CheckBox();
            HelpButton = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // BackpButton
            // 
            BackpButton.Dock = DockStyle.Top;
            BackpButton.Location = new Point(0, 0);
            BackpButton.Margin = new Padding(4);
            BackpButton.Name = "BackpButton";
            BackpButton.Size = new Size(508, 75);
            BackpButton.TabIndex = 0;
            BackpButton.Text = "نسخ احتياطي";
            BackpButton.UseVisualStyleBackColor = true;
            BackpButton.Click += BackpButton_Click;
            // 
            // UseRemovalbleDriveCheckBox
            // 
            UseRemovalbleDriveCheckBox.AutoSize = true;
            UseRemovalbleDriveCheckBox.Dock = DockStyle.Fill;
            UseRemovalbleDriveCheckBox.Location = new Point(258, 4);
            UseRemovalbleDriveCheckBox.Margin = new Padding(4);
            UseRemovalbleDriveCheckBox.Name = "UseRemovalbleDriveCheckBox";
            UseRemovalbleDriveCheckBox.Size = new Size(246, 39);
            UseRemovalbleDriveCheckBox.TabIndex = 1;
            UseRemovalbleDriveCheckBox.Text = "انسخ إلى وحدة تخزين قابلة للإزالة";
            UseRemovalbleDriveCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(UseRemovalbleDriveCheckBox, 0, 0);
            tableLayoutPanel1.Controls.Add(UseScheduleCheckBox, 1, 0);
            tableLayoutPanel1.Controls.Add(HelpButton, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 75);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tableLayoutPanel1.Size = new Size(508, 89);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // UseScheduleCheckBox
            // 
            UseScheduleCheckBox.AutoSize = true;
            UseScheduleCheckBox.Dock = DockStyle.Fill;
            UseScheduleCheckBox.Location = new Point(4, 4);
            UseScheduleCheckBox.Margin = new Padding(4);
            UseScheduleCheckBox.Name = "UseScheduleCheckBox";
            UseScheduleCheckBox.Size = new Size(246, 39);
            UseScheduleCheckBox.TabIndex = 2;
            UseScheduleCheckBox.Text = "استخدم الجدول الزمني";
            UseScheduleCheckBox.UseVisualStyleBackColor = true;
            // 
            // HelpButton
            // 
            HelpButton.Dock = DockStyle.Fill;
            HelpButton.Location = new Point(257, 50);
            HelpButton.Name = "HelpButton";
            HelpButton.Size = new Size(248, 36);
            HelpButton.TabIndex = 3;
            HelpButton.Text = "كيف تستعمل البرنامج";
            HelpButton.UseVisualStyleBackColor = true;
            HelpButton.Click += HelpButton_Click;
            // 
            // Backup
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 166);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(BackpButton);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Backup";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "النسخ الاحتياطي لقاعدة البيانات";
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button BackpButton;
        private CheckBox UseRemovalbleDriveCheckBox;
        private TableLayoutPanel tableLayoutPanel1;
        private CheckBox UseScheduleCheckBox;
        private Button HelpButton;
    }
}
