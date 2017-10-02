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
    public partial class ShowsAndDates : Form
    {
        public ShowsAndDates()
        {
            InitializeComponent();

            DataTable shows = Util.GetShowDataTable();
            dgv_shows.DataSource = shows;
        }
    }
}
