namespace Downloader
{
    partial class DownloaderWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloaderWindow));
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnDownloader = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // txtProgress
            // 
            this.txtProgress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProgress.Location = new System.Drawing.Point(16, 59);
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.ReadOnly = true;
            this.txtProgress.Size = new System.Drawing.Size(908, 19);
            this.txtProgress.TabIndex = 2;
            this.txtProgress.Text = "Esperando Usuario";
            this.txtProgress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtURL
            // 
            this.txtURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtURL.Location = new System.Drawing.Point(16, 22);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(683, 26);
            this.txtURL.TabIndex = 3;
            // 
            // btnDownloader
            // 
            this.btnDownloader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloader.Location = new System.Drawing.Point(722, 17);
            this.btnDownloader.Name = "btnDownloader";
            this.btnDownloader.Size = new System.Drawing.Size(91, 36);
            this.btnDownloader.TabIndex = 5;
            this.btnDownloader.Text = "Descargar";
            this.btnDownloader.UseVisualStyleBackColor = true;
            this.btnDownloader.Click += new System.EventHandler(this.btnDownloader_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(833, 17);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 36);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(16, 84);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(908, 33);
            this.pbProgress.TabIndex = 7;
            // 
            // DownloaderWindow
            // 
            this.ClientSize = new System.Drawing.Size(940, 136);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDownloader);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.txtProgress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DownloaderWindow";
            this.Text = "Descargador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtProgress;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnDownloader;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar pbProgress;
    }
}

