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
    public partial class MagnetLinks : Form
    {
        public MagnetLinks(DataTable links, string linkFor)
        {
            InitializeComponent();

            dgv_links.DataSource = links;
            dgv_links.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_links.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            lbl_links_for.Text = linkFor;
        }

        private void dgv_links_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                Process.Start(dgv.CurrentRow.Cells[1].Value.ToString());
            }
        }
    }
}
