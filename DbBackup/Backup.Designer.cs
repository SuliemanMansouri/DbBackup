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
            tableLayoutPanel1 = new TableLayoutPanel();
            OpenEditorButton = new Button();
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
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(OpenEditorButton, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 75);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(508, 42);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // OpenEditorButton
            // 
            OpenEditorButton.Dock = DockStyle.Fill;
            OpenEditorButton.Location = new Point(3, 3);
            OpenEditorButton.Name = "OpenEditorButton";
            OpenEditorButton.Size = new Size(248, 36);
            OpenEditorButton.TabIndex = 4;
            OpenEditorButton.Text = "الإعدادات";
            OpenEditorButton.UseVisualStyleBackColor = true;
            OpenEditorButton.Click += OpenEditorButton_Click;
            // 
            // Backup
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 117);
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
            ResumeLayout(false);
        }

        #endregion

        private Button BackpButton;
        private TableLayoutPanel tableLayoutPanel1;
        private Button OpenEditorButton;
    }
}
