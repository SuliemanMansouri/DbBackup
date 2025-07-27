namespace DbBackup
{
    partial class HowToUseTheApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HowToUseTheApp));
            HowToTextBox = new TextBox();
            SuspendLayout();
            // 
            // HowToTextBox
            // 
            HowToTextBox.Dock = DockStyle.Fill;
            HowToTextBox.Font = new Font("Segoe UI", 12F);
            HowToTextBox.Location = new Point(0, 0);
            HowToTextBox.Margin = new Padding(5);
            HowToTextBox.Multiline = true;
            HowToTextBox.Name = "HowToTextBox";
            HowToTextBox.ScrollBars = ScrollBars.Both;
            HowToTextBox.Size = new Size(609, 687);
            HowToTextBox.TabIndex = 0;
            // 
            // HowToUseTheApp
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(609, 687);
            Controls.Add(HowToTextBox);
            Font = new Font("Segoe UI", 14F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            Name = "HowToUseTheApp";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "كيف تستعمل البرنامج";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox HowToTextBox;
    }
}