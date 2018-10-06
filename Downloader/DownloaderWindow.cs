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

namespace Downloader
{
    public partial class DownloaderWindow : Form
    {
        private Thread thrDownload;
        private Stream strResponse;
        private Stream strLocal;
        private HttpWebRequest webRequest;
        private HttpWebResponse webResponse;
        private delegate void UpdateProgressCallback(Int64 bytesRead, Int64 totalBytes);
        private static int PercentProgress;

        public DownloaderWindow()
        {
            InitializeComponent();
        }
        
        private void DownloaderWindow_Load(object sender, EventArgs e)
        {

        }

        private void UpdateProgress(Int64 bytesRead, Int64 totalBytes)
        {
            PercentProgress = Convert.ToInt32((bytesRead * 100) / totalBytes);
            this.progressBar.Value = PercentProgress;
            txtProgress.Text = "Descargando " + bytesRead + " de " + totalBytes + " (" + PercentProgress + "%)";
        }

        private void Download()
        {
            using(WebClient wcDownload = new WebClient())
            {
                try
                {
                    webRequest = (HttpWebRequest)WebRequest.Create(this.txtURL.Text);
                    webRequest.Credentials = CredentialCache.DefaultCredentials;
                    webResponse = (HttpWebResponse)webRequest.GetResponse();
                    Int64 fileSize = webResponse.ContentLength;
                    strResponse = wcDownload.OpenRead(this.txtURL.Text);
                    strLocal = new FileStream(this.txtNombreArchivo.Text, FileMode.Create, FileAccess.Write, FileShare.None);
                    int bytesSize = 0;
                    byte[] downBuffer = new byte[2048];

                    while((bytesSize = strResponse.Read(downBuffer, 0, downBuffer.Length)) > 0)
                    {
                        strLocal.Write(downBuffer, 0, bytesSize);
                        this.Invoke(new UpdateProgressCallback(this.UpdateProgress), new object[] { strLocal.Length, fileSize });

                    }
                }
                finally
                {
                    strResponse.Close();
                    strLocal.Close();
                }
            }
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            txtProgress.Text = "Descarga iniciada...";
            thrDownload = new Thread(Download);
            thrDownload.Start();
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            webResponse.Close();
            strResponse.Close();
            strLocal.Close();
            thrDownload.Abort();
            progressBar.Value = 0;
            txtProgress.Text = "Descarga detenida...";
        }
        
    }
}
