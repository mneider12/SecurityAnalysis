using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SecurityAnalysis.Configuration
{
    [Serializable]
    public class Settings
    {
        public Settings()
        {
            Directory.CreateDirectory(CONFIGURATION_DIRECTORY);     //make sure configuration directory exists
            if (!File.Exists(SETTINGS_FILE_NAME))
            {
 
            }
        }

        private void setDefaults()
        {
           // databaseFilePath = 
        }

        public string databaseFilePath {
            get;
            private set;
        }

        #region private constants
        private const string CONFIGURATION_DIRECTORY = "Configuration";
        private const string SETTINGS_FILE_NAME = "Settings.bin";
       // private const
        #endregion
    }
}