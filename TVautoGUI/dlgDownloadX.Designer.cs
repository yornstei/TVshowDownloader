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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgDownloadX));
            this.txtbox_show_ep = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_download_x = new System.Windows.Forms.Button();
            this.chk_720p = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkbox_last_ep = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtbox_show_ep
            // 
            this.txtbox_show_ep.Location = new System.Drawing.Point(15, 159);
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
            this.label1.Size = new System.Drawing.Size(188, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter Movie Name or \r\nShow Name, Season and Episode: ";
            // 
            // btn_download_x
            // 
            this.btn_download_x.Location = new System.Drawing.Point(118, 204);
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
            this.chk_720p.Checked = true;
            this.chk_720p.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_720p.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_720p.Location = new System.Drawing.Point(15, 209);
            this.chk_720p.Name = "chk_720p";
            this.chk_720p.Size = new System.Drawing.Size(51, 18);
            this.chk_720p.TabIndex = 6;
            this.chk_720p.Text = "720P";
            this.chk_720p.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 91);
            this.label2.TabIndex = 7;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // chkbox_last_ep
            // 
            this.chkbox_last_ep.AutoSize = true;
            this.chkbox_last_ep.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbox_last_ep.Location = new System.Drawing.Point(15, 185);
            this.chkbox_last_ep.Name = "chkbox_last_ep";
            this.chkbox_last_ep.Size = new System.Drawing.Size(69, 18);
            this.chkbox_last_ep.TabIndex = 8;
            this.chkbox_last_ep.Text = "Last Ep.";
            this.chkbox_last_ep.UseVisualStyleBackColor = true;
            // 
            // dlgDownloadX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 238);
            this.Controls.Add(this.chkbox_last_ep);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkbox_last_ep;
    }
}