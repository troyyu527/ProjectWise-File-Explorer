using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectWiseApp
{
    public static class Program
    {
        /// <summary>  
        /// The main entry point for the application.  
        /// </summary>  
        [STAThread]
        static void Main()
        {
            // Set the PATH environment variable to include the ProjectWise bin directory for locating ProjectWise DLLS(API functions)
            string pwBinPath = @"C:\Program Files\Bentley\ProjectWise\bin";
            string currentPath = Environment.GetEnvironmentVariable("PATH");
            Environment.SetEnvironmentVariable("PATH", pwBinPath + ";" + currentPath);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PWExplorer());
        }

        
    }
}
