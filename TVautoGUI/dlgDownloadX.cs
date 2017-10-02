using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVautoGUI
{
    public partial class dlgDownloadX : Form
    {
        public dlgDownloadX()
        {
            InitializeComponent();
        }

        private void txtbox_show_name_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.Show("Ex. Arrow S02E01", TB, 0, 0, VisibleTime);
        }

        private void btn_download_x_Click(object sender, EventArgs e)
        {
            string showEp = txtbox_show_ep.Text;

            if(chk_720p.Checked)
                showEp += " 720p";

            string showEpForUrl = showEp.Replace(" ", "%20");

            string magFromTpb = Util.GetMagnetFromTPB(showEpForUrl);

            Process.Start(magFromTpb);
        }
    }
}
