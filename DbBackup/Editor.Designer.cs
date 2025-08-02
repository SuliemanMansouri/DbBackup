namespace DbBackup
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
            components = new System.ComponentModel.Container();
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
            lblMaxCopies = new Label();
            numMaxCopies = new NumericUpDown();
            toolTip1 = new ToolTip(components);
            label1 = new Label();
            ShowConfirmationMessageCheckBox = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxCopies).BeginInit();
            SuspendLayout();
            // 
            // txtServer
            // 
            txtServer.Location = new Point(50, 3);
            txtServer.Name = "txtServer";
            txtServer.RightToLeft = RightToLeft.No;
            txtServer.Size = new Size(200, 23);
            txtServer.TabIndex = 1;
            toolTip1.SetToolTip(txtServer, "اسم أو عنوان الخادم الذي يستضيف قاعدة البيانات.");
            // 
            // txtDatabase
            // 
            txtDatabase.Location = new Point(50, 32);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.RightToLeft = RightToLeft.No;
            txtDatabase.Size = new Size(200, 23);
            txtDatabase.TabIndex = 3;
            toolTip1.SetToolTip(txtDatabase, "اسم قاعدة البيانات التي سيتم نسخها احتياطيا.");
            // 
            // lstDestinations
            // 
            lstDestinations.Dock = DockStyle.Top;
            lstDestinations.Location = new Point(50, 61);
            lstDestinations.Name = "lstDestinations";
            lstDestinations.RightToLeft = RightToLeft.No;
            lstDestinations.Size = new Size(200, 94);
            lstDestinations.TabIndex = 5;
            toolTip1.SetToolTip(lstDestinations, "قائمة المجلدات التي سيتم حفظ النسخ الاحتياطية فيها.");
            // 
            // btnAddDestination
            // 
            btnAddDestination.Location = new Point(3, 3);
            btnAddDestination.Name = "btnAddDestination";
            btnAddDestination.Size = new Size(30, 21);
            btnAddDestination.TabIndex = 0;
            btnAddDestination.Text = "+";
            toolTip1.SetToolTip(btnAddDestination, "إضافة مجلد جديد إلى قائمة الوجهات.");
            // 
            // btnRemoveDestination
            // 
            btnRemoveDestination.Location = new Point(3, 31);
            btnRemoveDestination.Name = "btnRemoveDestination";
            btnRemoveDestination.Size = new Size(30, 22);
            btnRemoveDestination.TabIndex = 1;
            btnRemoveDestination.Text = "-";
            toolTip1.SetToolTip(btnRemoveDestination, "إزالة المجلد المحدد من قائمة الوجهات.");
            // 
            // chkSaveToRemovable
            // 
            chkSaveToRemovable.Location = new Point(146, 161);
            chkSaveToRemovable.Name = "chkSaveToRemovable";
            chkSaveToRemovable.Size = new Size(104, 24);
            chkSaveToRemovable.TabIndex = 8;
            toolTip1.SetToolTip(chkSaveToRemovable, "حفظ نسخة احتياطية أيضًا على وحدة تخزين خارجية إذا كانت متصلة.");
            // 
            // chkUseSchedule
            // 
            chkUseSchedule.Location = new Point(146, 191);
            chkUseSchedule.Name = "chkUseSchedule";
            chkUseSchedule.Size = new Size(104, 24);
            chkUseSchedule.TabIndex = 10;
            toolTip1.SetToolTip(chkUseSchedule, "تفعيل النسخ الاحتياطي التلقائي في الأوقات المجدولة.");
            // 
            // lstScheduledTimes
            // 
            lstScheduledTimes.Dock = DockStyle.Top;
            lstScheduledTimes.Location = new Point(50, 221);
            lstScheduledTimes.Name = "lstScheduledTimes";
            lstScheduledTimes.Size = new Size(200, 94);
            lstScheduledTimes.TabIndex = 12;
            toolTip1.SetToolTip(lstScheduledTimes, "الأوقات المجدولة (بتنسيق HH:mm) لتنفيذ النسخ الاحتياطي تلقائيًا.");
            // 
            // btnAddTime
            // 
            btnAddTime.Location = new Point(3, 3);
            btnAddTime.Name = "btnAddTime";
            btnAddTime.Size = new Size(30, 23);
            btnAddTime.TabIndex = 1;
            btnAddTime.Text = "+";
            toolTip1.SetToolTip(btnAddTime, "إضافة وقت جديد إلى جدول النسخ الاحتياطي.");
            // 
            // btnRemoveTime
            // 
            btnRemoveTime.Location = new Point(3, 32);
            btnRemoveTime.Name = "btnRemoveTime";
            btnRemoveTime.Size = new Size(30, 23);
            btnRemoveTime.TabIndex = 0;
            btnRemoveTime.Text = "-";
            toolTip1.SetToolTip(btnRemoveTime, "إزالة الوقت المحدد من جدول النسخ الاحتياطي.");
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(306, 370);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(80, 30);
            btnLoad.TabIndex = 16;
            btnLoad.Text = "فتح";
            toolTip1.SetToolTip(btnLoad, "تحميل الإعدادات من ملف الإعدادات.");
            // 
            // btnSave
            // 
            btnSave.Location = new Point(170, 370);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(80, 30);
            btnSave.TabIndex = 17;
            btnSave.Text = "حفظ";
            toolTip1.SetToolTip(btnSave, "حفظ الإعدادات الحالية إلى ملف الإعدادات.");
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.Dock = DockStyle.Fill;
            lblServer.Location = new Point(256, 0);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(130, 29);
            lblServer.TabIndex = 0;
            lblServer.Text = "الخادم:";
            lblServer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDatabase
            // 
            lblDatabase.AutoSize = true;
            lblDatabase.Dock = DockStyle.Fill;
            lblDatabase.Location = new Point(256, 29);
            lblDatabase.Name = "lblDatabase";
            lblDatabase.Size = new Size(130, 29);
            lblDatabase.TabIndex = 2;
            lblDatabase.Text = "قاعدة البيانات:";
            lblDatabase.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDestinations
            // 
            lblDestinations.AutoSize = true;
            lblDestinations.Dock = DockStyle.Fill;
            lblDestinations.Location = new Point(256, 58);
            lblDestinations.Name = "lblDestinations";
            lblDestinations.Size = new Size(130, 100);
            lblDestinations.TabIndex = 4;
            lblDestinations.Text = "مجلدات النسخ الاحتياطي:";
            lblDestinations.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSaveToRemovable
            // 
            lblSaveToRemovable.AutoSize = true;
            lblSaveToRemovable.Dock = DockStyle.Fill;
            lblSaveToRemovable.Location = new Point(256, 158);
            lblSaveToRemovable.Name = "lblSaveToRemovable";
            lblSaveToRemovable.Size = new Size(130, 30);
            lblSaveToRemovable.TabIndex = 7;
            lblSaveToRemovable.Text = "احفظ على وحدة خارجية:";
            lblSaveToRemovable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUseSchedule
            // 
            lblUseSchedule.AutoSize = true;
            lblUseSchedule.Dock = DockStyle.Fill;
            lblUseSchedule.Location = new Point(256, 188);
            lblUseSchedule.Name = "lblUseSchedule";
            lblUseSchedule.Size = new Size(130, 30);
            lblUseSchedule.TabIndex = 9;
            lblUseSchedule.Text = "استخدم الجدولة:";
            lblUseSchedule.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblScheduledTimes
            // 
            lblScheduledTimes.AutoSize = true;
            lblScheduledTimes.Dock = DockStyle.Fill;
            lblScheduledTimes.Location = new Point(256, 218);
            lblScheduledTimes.Name = "lblScheduledTimes";
            lblScheduledTimes.Size = new Size(130, 100);
            lblScheduledTimes.TabIndex = 11;
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
            tableLayoutPanel1.Controls.Add(lblMaxCopies, 0, 6);
            tableLayoutPanel1.Controls.Add(numMaxCopies, 1, 6);
            tableLayoutPanel1.Controls.Add(btnLoad, 0, 8);
            tableLayoutPanel1.Controls.Add(label1, 0, 7);
            tableLayoutPanel1.Controls.Add(btnSave, 1, 8);
            tableLayoutPanel1.Controls.Add(ShowConfirmationMessageCheckBox, 1, 7);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 9;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(389, 417);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(btnAddDestination, 0, 0);
            tableLayoutPanel2.Controls.Add(btnRemoveDestination, 0, 1);
            tableLayoutPanel2.Location = new Point(8, 61);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(36, 56);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.Controls.Add(btnAddTime, 0, 0);
            tableLayoutPanel3.Controls.Add(btnRemoveTime, 0, 1);
            tableLayoutPanel3.Location = new Point(8, 221);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(36, 58);
            tableLayoutPanel3.TabIndex = 13;
            // 
            // lblMaxCopies
            // 
            lblMaxCopies.AutoSize = true;
            lblMaxCopies.Location = new Point(275, 318);
            lblMaxCopies.Name = "lblMaxCopies";
            lblMaxCopies.Size = new Size(111, 15);
            lblMaxCopies.TabIndex = 14;
            lblMaxCopies.Text = "عدد النسخ الاحتياطية:";
            // 
            // numMaxCopies
            // 
            numMaxCopies.Location = new Point(130, 321);
            numMaxCopies.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxCopies.Name = "numMaxCopies";
            numMaxCopies.Size = new Size(120, 23);
            numMaxCopies.TabIndex = 15;
            toolTip1.SetToolTip(numMaxCopies, "الحد الأقصى لعدد النسخ الاحتياطية التي سيتم الاحتفاظ بها في كل مجلد وجهة.");
            numMaxCopies.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(283, 347);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 18;
            label1.Text = "إعرض رسالة التأكيد:";
            // 
            // ShowConfirmationMessageCheckBox
            // 
            ShowConfirmationMessageCheckBox.AutoSize = true;
            ShowConfirmationMessageCheckBox.Location = new Point(235, 350);
            ShowConfirmationMessageCheckBox.Name = "ShowConfirmationMessageCheckBox";
            ShowConfirmationMessageCheckBox.Size = new Size(15, 14);
            ShowConfirmationMessageCheckBox.TabIndex = 19;
            ShowConfirmationMessageCheckBox.UseVisualStyleBackColor = true;
            // 
            // Editor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 417);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 9F);
            Name = "Editor";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "تعديل إعدادات النسخ الاحتياطي";
            Load += Editor_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numMaxCopies).EndInit();
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
        private Label lblMaxCopies;
        private NumericUpDown numMaxCopies;
        private ToolTip toolTip1;
        private Label label1;
        private CheckBox ShowConfirmationMessageCheckBox;
    }
}
