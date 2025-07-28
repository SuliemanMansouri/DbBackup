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
            progressBar1 = new ProgressBar();
            ProgressLabel = new Label();
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
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(progressBar1, 0, 0);
            tableLayoutPanel1.Controls.Add(ProgressLabel, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 75);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(508, 44);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // progressBar1
            // 
            tableLayoutPanel1.SetColumnSpan(progressBar1, 2);
            progressBar1.Dock = DockStyle.Fill;
            progressBar1.Location = new Point(3, 3);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(502, 16);
            progressBar1.TabIndex = 5;
            // 
            // ProgressLabel
            // 
            ProgressLabel.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(ProgressLabel, 2);
            ProgressLabel.Dock = DockStyle.Fill;
            ProgressLabel.Location = new Point(3, 22);
            ProgressLabel.Name = "ProgressLabel";
            ProgressLabel.Size = new Size(502, 22);
            ProgressLabel.TabIndex = 6;
            // 
            // Backup
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 125);
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
            PerformLayout();
        }

        #endregion

        private Button BackpButton;
        private TableLayoutPanel tableLayoutPanel1;
        private ProgressBar progressBar1;
        private Label ProgressLabel;
    }
}
