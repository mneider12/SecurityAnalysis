using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SecurityAnalysis
{
    public partial class DatabaseViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void initializeDatabase()
        {
            Directory.CreateDirectory(DATABASE_DIRECTORY);      // Make sure the database directory exists

        }

        private const string DATABASE_DIRECTORY = "Data";
        private const string DATABASE_FILE_NAME = "data.db";
    }
}