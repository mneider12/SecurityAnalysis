using System;
using SecurityAnalysis.Core.Database;
using SecurityAnalysis.Core.FileSystem;

namespace SecurityAnalysis.Admin
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            FileSystemHelper.create();
            DatabaseHelper.create();
        }

        protected void btnDeleteDatabase_Click(object sender, EventArgs e)
        {
            DatabaseHelper.delete();
        }

        protected void btnBackupDatabase_Click(object sender, EventArgs e)
        {
            DatabaseHelper.backup();
        }
    }
}