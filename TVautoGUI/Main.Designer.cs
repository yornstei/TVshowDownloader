namespace TVautoGUI
{
    partial class Main
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
            this.btn_cur_shows = new System.Windows.Forms.Button();
            this.btn_run = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_down_x = new System.Windows.Forms.Button();
            this.btn_add_show = new System.Windows.Forms.Button();
            this.btn_show_info = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_cur_shows
            // 
            this.btn_cur_shows.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cur_shows.Location = new System.Drawing.Point(46, 43);
            this.btn_cur_shows.Name = "btn_cur_shows";
            this.btn_cur_shows.Size = new System.Drawing.Size(103, 54);
            this.btn_cur_shows.TabIndex = 0;
            this.btn_cur_shows.Text = "My Shows\r\n+\r\nNext Air";
            this.btn_cur_shows.UseVisualStyleBackColor = true;
            this.btn_cur_shows.Click += new System.EventHandler(this.btn_cur_shows_Click);
            // 
            // btn_run
            // 
            this.btn_run.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_run.Location = new System.Drawing.Point(46, 193);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(103, 23);
            this.btn_run.TabIndex = 1;
            this.btn_run.Text = "Run Process";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "TVautoDownloader";
            // 
            // btn_down_x
            // 
            this.btn_down_x.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_down_x.Location = new System.Drawing.Point(46, 161);
            this.btn_down_x.Name = "btn_down_x";
            this.btn_down_x.Size = new System.Drawing.Size(103, 23);
            this.btn_down_x.TabIndex = 3;
            this.btn_down_x.Text = "Download X";
            this.btn_down_x.UseVisualStyleBackColor = true;
            this.btn_down_x.Click += new System.EventHandler(this.btn_down_x_Click);
            // 
            // btn_add_show
            // 
            this.btn_add_show.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_show.Location = new System.Drawing.Point(46, 103);
            this.btn_add_show.Name = "btn_add_show";
            this.btn_add_show.Size = new System.Drawing.Size(103, 23);
            this.btn_add_show.TabIndex = 4;
            this.btn_add_show.Text = "Add Show";
            this.btn_add_show.UseVisualStyleBackColor = true;
            this.btn_add_show.Click += new System.EventHandler(this.btn_add_show_Click);
            // 
            // btn_show_info
            // 
            this.btn_show_info.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_show_info.Location = new System.Drawing.Point(46, 132);
            this.btn_show_info.Name = "btn_show_info";
            this.btn_show_info.Size = new System.Drawing.Size(103, 23);
            this.btn_show_info.TabIndex = 5;
            this.btn_show_info.Text = "Show/Ep Info";
            this.btn_show_info.UseVisualStyleBackColor = true;
            this.btn_show_info.Click += new System.EventHandler(this.btn_show_info_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 226);
            this.Controls.Add(this.btn_show_info);
            this.Controls.Add(this.btn_add_show);
            this.Controls.Add(this.btn_down_x);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.btn_cur_shows);
            this.Name = "Main";
            this.Text = "Main Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cur_shows;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_down_x;
        private System.Windows.Forms.Button btn_add_show;
        private System.Windows.Forms.Button btn_show_info;
    }
}

