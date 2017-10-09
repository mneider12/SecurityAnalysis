using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SecurityAnalysis.Core.FileSystem
{
    public static class FileSystemHelper
    {
        public static void create()
        {
            Directory.CreateDirectory(getDataDirectory());
            Directory.CreateDirectory(getBackupDirectory());
        }

        public static string getDataDirectory()
        {
            string directoryPath = Path.Combine(HOME_DIRECTORY, DATA_DIRECTORY);
            return HttpContext.Current.Server.MapPath(directoryPath);
        }

        public static string getBackupDirectory()
        {
            string directoryPath = getDataDirectory();
            return Path.Combine(directoryPath, BACKUP_DIRECTORY);
        }

        private const string HOME_DIRECTORY = "~";
        private const string DATA_DIRECTORY = "data";
        private const string BACKUP_DIRECTORY = "backup";
    }
}