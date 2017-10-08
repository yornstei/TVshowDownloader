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
            //for tool tip before adding label in form
            //TextBox TB = (TextBox)sender;
            //int VisibleTime = 2000;  //in milliseconds

            //ToolTip tt = new ToolTip();
            //tt.Show("Ex. Arrow S02E01", TB, 0, 0, VisibleTime);
        }

        private async void btn_download_x_Click(object sender, EventArgs e)
        {
            string xForDownload = "";

            if (chkbox_last_ep.Checked)
            {
                Tuple<string, string> showEp = await Util.GetLastSeasonAndEpisode(txtbox_show_ep.Text);

                xForDownload = txtbox_show_ep.Text + " S" + showEp.Item1 + "E" + showEp.Item2;   
            }
            else
            {
                xForDownload = txtbox_show_ep.Text;

                if (chk_720p.Checked)
                    xForDownload += " 720p";
            }

            string xForUrl = xForDownload.Trim().Replace(" ", "%20");

            DataTable links = Util.GetMagnetsFromTPB(xForUrl);

            if (links.Rows.Count > 0)
            {
                MagnetLinks formMagnetLinks = new MagnetLinks(links, xForDownload);
                formMagnetLinks.Show();
            }
            else
            {
                MessageBox.Show("Your search returned no results!", "Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
