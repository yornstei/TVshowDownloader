using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVautoGUI
{
    public partial class dlgShowToSearch : Form
    {
        public dlgShowToSearch()
        {
            InitializeComponent();
        }

        private async void btn_search_Click(object sender, EventArgs e)
        {
            TVmazeShowEpData showData = await Util.GetShowEpisodesData(txtbox_show.Text);
            ShowEpInfo formShowEpInfo = new ShowEpInfo(showData);
            formShowEpInfo.Show();
        }
    }
}
