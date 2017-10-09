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
using System.Data.SQLite;
using SecurityAnalysis.Core.Database;

namespace SecurityAnalysis.Admin
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            DatabaseHelper.create();
        }

        private const string DATABASE_DIRECTORY = "../Data";
        private const string DATABASE_FILE_NAME = "database.sqlite";
    }
}