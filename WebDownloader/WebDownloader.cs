using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.Linq;

namespace WebDownloader
{
    public partial class WebDownloaderForm : Form
    {
        public WebDownloaderForm()
        {
            InitializeComponent();
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            StartDownload();
        }

        bool isDownloading = false, validURL = true;
        WebClient client;

        private void StartDownload()
        {
            if (isDownloading)
            {
                MessageBox.Show("Already downloading");
                return;
            }
            if (!validURL)
            {
                MessageBox.Show("URL is not valid.\n Did you specify \"http://\" or \"https://\"");
                return;
            }
            isDownloading = true;
            client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            string filename = URLTextBox.Text.Split('/').Last();
            client.DownloadFileAsync(new Uri(URLTextBox.Text), filename);
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            long bytesIn = e.BytesReceived;
            long totalBytes = e.TotalBytesToReceive;
            int percentage = e.ProgressPercentage;
            StatusLabel.Text = "Downloaded " + (e.BytesReceived / 1024).ToString() + " / "
                + (e.TotalBytesToReceive / 1024).ToString() + " "
                + percentage.ToString() + "%";
            DownloadProgressBar.Value = percentage;
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                StatusLabel.Text = "Cancelled";
            else if (e.Error != null)
                StatusLabel.Text = e.Error.Message;
            else
                StatusLabel.Text = "Completed";
            isDownloading = false;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (isDownloading)
            {
                client.CancelAsync();
                StatusLabel.Text = "Stopped";
            }
        }

        private void URLTextBox_TextChanged(object sender, EventArgs e)
        {
            Uri uriResult;
            validURL = Uri.TryCreate(URLTextBox.Text, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (validURL)
                StatusLabel.Text = "Valid URL";
            else
                StatusLabel.Text = "Not a valid URL";
        }
    }
}

