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
    public partial class dlgAddShow : Form
    {
        public dlgAddShow()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (!Util.CheckShowExists(txtbox_show_name.Text))
                MessageBox.Show("Show doesn't exist!" + Environment.NewLine +
                                "Check www.airdates.com for proper show names.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
            {
                bool success = Util.AddShow(txtbox_show_name.Text);
                if (success)
                {
                    MessageBox.Show("Show Added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtbox_show_name.Text = "";
                }
                else
                {
                    MessageBox.Show("Error adding show!" , "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
    }
}
