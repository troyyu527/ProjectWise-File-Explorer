using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectWiseApp
{
    public partial class PWSetting : Form
    {
        public PWSetting()
        {
            InitializeComponent();
            UserLb.Text = PWAPI.GetCurrentUsername();
            ServerTb.Text = Properties.Settings.Default.Server;
            DatasourceTb.Text = Properties.Settings.Default.Datasource;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void UserLb_Click(object sender, EventArgs e)
        {

        }

        private void SaveNCloseBt_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Server = ServerTb.Text;
            Properties.Settings.Default.Datasource = DatasourceTb.Text;
            this.Close();
        }

        private void DefaultBt_Click(object sender, EventArgs e)
        {
            ServerTb.Text = "aecom-na-pw.bentley.com";
            DatasourceTb.Text = "AECOM_USA_New_York";
        }
    }
}
