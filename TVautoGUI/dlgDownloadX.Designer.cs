namespace TVautoGUI
{
    partial class dlgDownloadX
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
            this.txtbox_show_ep = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_download_x = new System.Windows.Forms.Button();
            this.chk_720p = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtbox_show_ep
            // 
            this.txtbox_show_ep.Location = new System.Drawing.Point(16, 44);
            this.txtbox_show_ep.Name = "txtbox_show_ep";
            this.txtbox_show_ep.Size = new System.Drawing.Size(178, 20);
            this.txtbox_show_ep.TabIndex = 5;
            this.txtbox_show_ep.Enter += new System.EventHandler(this.txtbox_show_name_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Show Name, Season and Episode: ";
            // 
            // btn_download_x
            // 
            this.btn_download_x.Location = new System.Drawing.Point(119, 79);
            this.btn_download_x.Name = "btn_download_x";
            this.btn_download_x.Size = new System.Drawing.Size(75, 23);
            this.btn_download_x.TabIndex = 3;
            this.btn_download_x.Text = "Download";
            this.btn_download_x.UseVisualStyleBackColor = true;
            this.btn_download_x.Click += new System.EventHandler(this.btn_download_x_Click);
            // 
            // chk_720p
            // 
            this.chk_720p.AutoSize = true;
            this.chk_720p.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_720p.Location = new System.Drawing.Point(16, 83);
            this.chk_720p.Name = "chk_720p";
            this.chk_720p.Size = new System.Drawing.Size(51, 18);
            this.chk_720p.TabIndex = 6;
            this.chk_720p.Text = "720P";
            this.chk_720p.UseVisualStyleBackColor = true;
            // 
            // dlgDownloadX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 114);
            this.Controls.Add(this.chk_720p);
            this.Controls.Add(this.txtbox_show_ep);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_download_x);
            this.Name = "dlgDownloadX";
            this.Text = "Download X";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbox_show_ep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_download_x;
        private System.Windows.Forms.CheckBox chk_720p;
    }
}