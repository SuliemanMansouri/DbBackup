namespace ConfigEditor
{
    partial class Editor
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
            txtServer = new TextBox();
            txtDatabase = new TextBox();
            lstDestinations = new ListBox();
            btnAddDestination = new Button();
            btnRemoveDestination = new Button();
            chkSaveToRemovable = new CheckBox();
            chkUseSchedule = new CheckBox();
            lstScheduledTimes = new ListBox();
            btnAddTime = new Button();
            btnRemoveTime = new Button();
            btnLoad = new Button();
            btnSave = new Button();
            lblServer = new Label();
            lblDatabase = new Label();
            lblDestinations = new Label();
            lblSaveToRemovable = new Label();
            lblUseSchedule = new Label();
            lblScheduledTimes = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // txtServer
            // 
            txtServer.Location = new Point(63, 4);
            txtServer.Margin = new Padding(4);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(256, 29);
            txtServer.TabIndex = 1;
            // 
            // txtDatabase
            // 
            txtDatabase.Location = new Point(63, 41);
            txtDatabase.Margin = new Padding(4);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new Size(256, 29);
            txtDatabase.TabIndex = 3;
            // 
            // lstDestinations
            // 
            lstDestinations.Dock = DockStyle.Top;
            lstDestinations.Location = new Point(63, 78);
            lstDestinations.Margin = new Padding(4);
            lstDestinations.Name = "lstDestinations";
            lstDestinations.Size = new Size(256, 109);
            lstDestinations.TabIndex = 5;
            // 
            // btnAddDestination
            // 
            btnAddDestination.Location = new Point(4, 4);
            btnAddDestination.Margin = new Padding(4);
            btnAddDestination.Name = "btnAddDestination";
            btnAddDestination.Size = new Size(39, 32);
            btnAddDestination.TabIndex = 6;
            btnAddDestination.Text = "+";
            // 
            // btnRemoveDestination
            // 
            btnRemoveDestination.Location = new Point(4, 44);
            btnRemoveDestination.Margin = new Padding(4);
            btnRemoveDestination.Name = "btnRemoveDestination";
            btnRemoveDestination.Size = new Size(39, 32);
            btnRemoveDestination.TabIndex = 7;
            btnRemoveDestination.Text = "-";
            // 
            // chkSaveToRemovable
            // 
            chkSaveToRemovable.Location = new Point(185, 195);
            chkSaveToRemovable.Margin = new Padding(4);
            chkSaveToRemovable.Name = "chkSaveToRemovable";
            chkSaveToRemovable.Size = new Size(134, 34);
            chkSaveToRemovable.TabIndex = 9;
            // 
            // chkUseSchedule
            // 
            chkUseSchedule.Location = new Point(185, 237);
            chkUseSchedule.Margin = new Padding(4);
            chkUseSchedule.Name = "chkUseSchedule";
            chkUseSchedule.Size = new Size(134, 34);
            chkUseSchedule.TabIndex = 11;
            // 
            // lstScheduledTimes
            // 
            lstScheduledTimes.Dock = DockStyle.Top;
            lstScheduledTimes.Location = new Point(63, 279);
            lstScheduledTimes.Margin = new Padding(4);
            lstScheduledTimes.Name = "lstScheduledTimes";
            lstScheduledTimes.Size = new Size(256, 130);
            lstScheduledTimes.TabIndex = 13;
            // 
            // btnAddTime
            // 
            btnAddTime.Location = new Point(4, 4);
            btnAddTime.Margin = new Padding(4);
            btnAddTime.Name = "btnAddTime";
            btnAddTime.Size = new Size(39, 32);
            btnAddTime.TabIndex = 14;
            btnAddTime.Text = "+";
            // 
            // btnRemoveTime
            // 
            btnRemoveTime.Location = new Point(4, 44);
            btnRemoveTime.Margin = new Padding(4);
            btnRemoveTime.Name = "btnRemoveTime";
            btnRemoveTime.Size = new Size(39, 32);
            btnRemoveTime.TabIndex = 15;
            btnRemoveTime.Text = "-";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(393, 417);
            btnLoad.Margin = new Padding(4);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(103, 42);
            btnLoad.TabIndex = 16;
            btnLoad.Text = "فتح";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(216, 417);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(103, 42);
            btnSave.TabIndex = 17;
            btnSave.Text = "حفظ";
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.Dock = DockStyle.Fill;
            lblServer.Location = new Point(327, 0);
            lblServer.Margin = new Padding(4, 0, 4, 0);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(169, 37);
            lblServer.TabIndex = 0;
            lblServer.Text = "الخادم:";
            lblServer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDatabase
            // 
            lblDatabase.AutoSize = true;
            lblDatabase.Dock = DockStyle.Fill;
            lblDatabase.Location = new Point(327, 37);
            lblDatabase.Margin = new Padding(4, 0, 4, 0);
            lblDatabase.Name = "lblDatabase";
            lblDatabase.Size = new Size(169, 37);
            lblDatabase.TabIndex = 2;
            lblDatabase.Text = "قاعدة البيانات:";
            lblDatabase.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDestinations
            // 
            lblDestinations.AutoSize = true;
            lblDestinations.Dock = DockStyle.Fill;
            lblDestinations.Location = new Point(327, 74);
            lblDestinations.Margin = new Padding(4, 0, 4, 0);
            lblDestinations.Name = "lblDestinations";
            lblDestinations.Size = new Size(169, 117);
            lblDestinations.TabIndex = 4;
            lblDestinations.Text = "مجلدات النسخ الاحتياطي:";
            lblDestinations.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSaveToRemovable
            // 
            lblSaveToRemovable.AutoSize = true;
            lblSaveToRemovable.Dock = DockStyle.Fill;
            lblSaveToRemovable.Location = new Point(327, 191);
            lblSaveToRemovable.Margin = new Padding(4, 0, 4, 0);
            lblSaveToRemovable.Name = "lblSaveToRemovable";
            lblSaveToRemovable.Size = new Size(169, 42);
            lblSaveToRemovable.TabIndex = 8;
            lblSaveToRemovable.Text = "احفظ على وحدة خارجية:";
            lblSaveToRemovable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUseSchedule
            // 
            lblUseSchedule.AutoSize = true;
            lblUseSchedule.Dock = DockStyle.Fill;
            lblUseSchedule.Location = new Point(327, 233);
            lblUseSchedule.Margin = new Padding(4, 0, 4, 0);
            lblUseSchedule.Name = "lblUseSchedule";
            lblUseSchedule.Size = new Size(169, 42);
            lblUseSchedule.TabIndex = 10;
            lblUseSchedule.Text = "استخدم الجدولة:";
            lblUseSchedule.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblScheduledTimes
            // 
            lblScheduledTimes.AutoSize = true;
            lblScheduledTimes.Dock = DockStyle.Fill;
            lblScheduledTimes.Location = new Point(327, 275);
            lblScheduledTimes.Margin = new Padding(4, 0, 4, 0);
            lblScheduledTimes.Name = "lblScheduledTimes";
            lblScheduledTimes.Size = new Size(169, 138);
            lblScheduledTimes.TabIndex = 12;
            lblScheduledTimes.Text = "أوقات النسخ المجدول:";
            lblScheduledTimes.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(lblServer, 0, 0);
            tableLayoutPanel1.Controls.Add(btnSave, 1, 6);
            tableLayoutPanel1.Controls.Add(btnLoad, 0, 6);
            tableLayoutPanel1.Controls.Add(lstScheduledTimes, 1, 5);
            tableLayoutPanel1.Controls.Add(lblScheduledTimes, 0, 5);
            tableLayoutPanel1.Controls.Add(chkUseSchedule, 1, 4);
            tableLayoutPanel1.Controls.Add(lblUseSchedule, 0, 4);
            tableLayoutPanel1.Controls.Add(chkSaveToRemovable, 1, 3);
            tableLayoutPanel1.Controls.Add(lblSaveToRemovable, 0, 3);
            tableLayoutPanel1.Controls.Add(lstDestinations, 1, 2);
            tableLayoutPanel1.Controls.Add(lblDestinations, 0, 2);
            tableLayoutPanel1.Controls.Add(txtDatabase, 1, 1);
            tableLayoutPanel1.Controls.Add(lblDatabase, 0, 1);
            tableLayoutPanel1.Controls.Add(txtServer, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 2, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 2, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(500, 465);
            tableLayoutPanel1.TabIndex = 18;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(btnAddDestination, 0, 0);
            tableLayoutPanel2.Controls.Add(btnRemoveDestination, 0, 1);
            tableLayoutPanel2.Location = new Point(8, 78);
            tableLayoutPanel2.Margin = new Padding(4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(47, 80);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.Controls.Add(btnAddTime, 0, 0);
            tableLayoutPanel3.Controls.Add(btnRemoveTime, 0, 1);
            tableLayoutPanel3.Location = new Point(8, 279);
            tableLayoutPanel3.Margin = new Padding(4);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(47, 80);
            tableLayoutPanel3.TabIndex = 14;
            // 
            // Editor
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 465);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            Name = "Editor";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "تعديل إعدادات النسخ الاحتياطي";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.ListBox lstDestinations;
        private System.Windows.Forms.Button btnAddDestination;
        private System.Windows.Forms.Button btnRemoveDestination;
        private System.Windows.Forms.CheckBox chkSaveToRemovable;
        private System.Windows.Forms.CheckBox chkUseSchedule;
        private System.Windows.Forms.ListBox lstScheduledTimes;
        private System.Windows.Forms.Button btnAddTime;
        private System.Windows.Forms.Button btnRemoveTime;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lblDestinations;
        private System.Windows.Forms.Label lblSaveToRemovable;
        private System.Windows.Forms.Label lblUseSchedule;
        private System.Windows.Forms.Label lblScheduledTimes;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
    }
}
