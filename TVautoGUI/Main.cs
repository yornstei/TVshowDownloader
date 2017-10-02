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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            Program.Main(new[] {"test"});
            Close();
        }

        private void btn_add_show_Click(object sender, EventArgs e)
        {
            //Util.GetShowDataTable();
            dlgAddShow formAddShow = new dlgAddShow();
            formAddShow.Show();
        }

        private void btn_cur_shows_Click(object sender, EventArgs e)
        {
            ShowsAndDates formShowsAndDates = new ShowsAndDates();
            formShowsAndDates.Show();
        }

        private void btn_down_x_Click(object sender, EventArgs e)
        {
            dlgDownloadX formDlgDownloadX = new dlgDownloadX();
            formDlgDownloadX.Show();
        }
    }
}
