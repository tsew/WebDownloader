namespace WebDownloader
{
    partial class WebDownloaderForm
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
            this.DownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StopButton = new System.Windows.Forms.Button();
            this.URLTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DownloadProgressBar
            // 
            this.DownloadProgressBar.Location = new System.Drawing.Point(12, 99);
            this.DownloadProgressBar.Name = "DownloadProgressBar";
            this.DownloadProgressBar.Size = new System.Drawing.Size(260, 23);
            this.DownloadProgressBar.TabIndex = 0;
            // 
            // DownloadButton
            // 
            this.DownloadButton.Location = new System.Drawing.Point(12, 39);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(75, 23);
            this.DownloadButton.TabIndex = 1;
            this.DownloadButton.Text = "Download";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(12, 74);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(37, 13);
            this.StatusLabel.TabIndex = 2;
            this.StatusLabel.Text = "Status";
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(197, 39);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // URLTextBox
            // 
            this.URLTextBox.Location = new System.Drawing.Point(12, 13);
            this.URLTextBox.Name = "URLTextBox";
            this.URLTextBox.Size = new System.Drawing.Size(260, 20);
            this.URLTextBox.TabIndex = 4;
            this.URLTextBox.Text = "https://dl.armbian.com/bananapi/Ubuntu_xenial_next.7z";
            this.URLTextBox.TextChanged += new System.EventHandler(this.URLTextBox_TextChanged);
            // 
            // WebDownloaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 138);
            this.Controls.Add(this.URLTextBox);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.DownloadProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "WebDownloaderForm";
            this.Text = "Web Downloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar DownloadProgressBar;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.TextBox URLTextBox;
    }
}

