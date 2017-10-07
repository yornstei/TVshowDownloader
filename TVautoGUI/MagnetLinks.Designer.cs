namespace TVautoGUI
{
    partial class MagnetLinks
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
            this.dgv_links = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_links_for = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_links)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_links
            // 
            this.dgv_links.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_links.Location = new System.Drawing.Point(12, 34);
            this.dgv_links.Name = "dgv_links";
            this.dgv_links.Size = new System.Drawing.Size(573, 210);
            this.dgv_links.TabIndex = 0;
            this.dgv_links.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_links_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Links For:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Click on a row to download";
            // 
            // lbl_links_for
            // 
            this.lbl_links_for.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_links_for.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_links_for.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbl_links_for.Location = new System.Drawing.Point(112, 12);
            this.lbl_links_for.Name = "lbl_links_for";
            this.lbl_links_for.Size = new System.Drawing.Size(473, 19);
            this.lbl_links_for.TabIndex = 3;
            this.lbl_links_for.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MagnetLinks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 261);
            this.Controls.Add(this.lbl_links_for);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_links);
            this.Name = "MagnetLinks";
            this.Text = "Magnet Links";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_links)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_links;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_links_for;
    }
}