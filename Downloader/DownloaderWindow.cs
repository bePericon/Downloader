using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net;
using System.Diagnostics;

namespace Downloader
{
    public partial class DownloaderWindow : Form
    {
        WebClient webClient = new WebClient();
        Stopwatch sw = new Stopwatch();
        string fileName = null;

        public DownloaderWindow()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(UpdateProgress);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Downloader);

            base.OnLoad(e);
        }

        private void UpdateProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            string bytesRead = (e.BytesReceived / 1024d / 1024d).ToString("0.00");
            string totalBytes = (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00");
            string bytes = string.Format("{0} MB's / {1} MB's", bytesRead, totalBytes);
            //string speed = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));
            int percentage = e.ProgressPercentage;

            pbProgress.Value = percentage;
            txtProgress.Text = "Descargando " + percentage.ToString() + " %" + " - " + bytes;// + " - " + speed;
        }

        private void Downloader(object sender, AsyncCompletedEventArgs e)
        {
            sw.Reset();
            pbProgress.Value = 0;
            txtProgress.Text = "0%";
            if (e.Cancelled == true)
            {
                MessageBox.Show("La descarga ha sido cancelada!");
            }
            else
            {
                if (MessageBox.Show("¿Desea abrir el archivo descargado?", "Archivo Descargado", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(fileName);
                }
            }
        }

        private bool ValidateURL()
        {
            return !string.IsNullOrEmpty(txtURL.Text);
        }

        private void btnDownloader_Click(object sender, EventArgs e)
        {
            if (ValidateURL())
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Todos los archivos|*.*";
                dialog.FileName = txtURL.Text.Substring(txtURL.Text.LastIndexOf("/") + 1);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName;
                    webClient.DownloadFileAsync(new Uri(txtURL.Text), fileName);
                }
            }
            else
                MessageBox.Show("Complete con alguna URL!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (webClient != null)
            {
                webClient.CancelAsync();
            }
        }
    }
}
