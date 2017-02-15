using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;

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
            client.DownloadFileAsync(new Uri(URLTextBox.Text), "armbian.7z");
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            StatusLabel.Text = "Downloaded " + (e.BytesReceived / 1024).ToString() + " / "
                + (e.TotalBytesToReceive / 1024).ToString() + " "
                + ((int)percentage).ToString() + "%";
            DownloadProgressBar.Value = int.Parse(Math.Truncate(percentage).ToString());
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

