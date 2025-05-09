using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
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
            ServerTb.Text = Properties.StoreSettings.Default.Server;
            DatasourceTb.Text = Properties.StoreSettings.Default.Datasource;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void UserLb_Click(object sender, EventArgs e)
        {

        }

        private void SaveNCloseBt_Click(object sender, EventArgs e)
        {
            Properties.StoreSettings.Default.Server = ServerTb.Text;
            Properties.StoreSettings.Default.Datasource = DatasourceTb.Text;
            this.Close();
        }

        private void DefaultBt_Click(object sender, EventArgs e)
        {
            // Load or set default settings from StoreSettings
            
            try
            {
                // Get the path to secrets.config.xml relative to the executing assembly
                string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "secrets.config.xml");
                if (File.Exists(configPath))
                {
                    ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap { ExeConfigFilename = configPath };
                    Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                    if (config.AppSettings.Settings["Server"] != null)
                    {
                        Properties.StoreSettings.Default.Server = config.AppSettings.Settings["Server"].Value;
                    }
                    if (config.AppSettings.Settings["Datasource"] != null)
                    {
                        Properties.StoreSettings.Default.Datasource = config.AppSettings.Settings["Datasource"].Value;
                    }
                    Properties.StoreSettings.Default.Save();
                    ServerTb.Text = Properties.StoreSettings.Default.Server;
                    DatasourceTb.Text = Properties.StoreSettings.Default.Datasource;
                }
                else
                {
                    MessageBox.Show("secrets.config.xml not found in the output directory. Using default settings.");
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                MessageBox.Show($"Error loading secrets.config.xml: {ex.Message}. Using default settings.");
            }
            
        }
    }
}
