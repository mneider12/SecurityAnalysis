using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SecurityAnalysis.Configuration;

namespace SecurityAnalysis.Admin
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(CONFIGURATION_DIRECTORY);
            if (!File.Exists(SETTINGS_FILE_NAME))
            {
               Settings = new Settings();
            }
            else
            {
                IFormatter formatter = new BinaryFormatter();
               // using (Stream stream = new FileStream("Configuration/Settings"))
            }
            Stream stream = new FileStream("Configuration/Settings.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            //FileStream configFileStream = new FileStream("")
            lblDatabaseLocation.Text = Directory.GetCurrentDirectory();
        }

        #region private constants
        private const string CONFIGURATION_DIRECTORY = "Configuration";
        private const string SETTINGS_FILE_NAME = "Settings.bin";
        #endregion

        #region private properties
        private Settings Settings { get; set; }
        #endregion
    }
}