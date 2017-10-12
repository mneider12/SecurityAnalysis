using System;
using SecurityAnalysis.Core.Database;
using SecurityAnalysis.Core.FileSystem;

namespace SecurityAnalysis.Admin
{
    /// <summary>
    /// Backend for admin page
    /// </summary>
    public partial class Admin : System.Web.UI.Page
    {
        /// <summary>
        /// Nothing to do on load
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Create the database from scratch
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        protected void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            FileSystemHelper.create();
            DatabaseHelper.create();
        }

        /// <summary>
        /// Delete the database entirely
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        protected void btnDeleteDatabase_Click(object sender, EventArgs e)
        {
            DatabaseHelper.delete();
        }

        /// <summary>
        /// Backup the database to the data/backup directory
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        protected void btnBackupDatabase_Click(object sender, EventArgs e)
        {
            DatabaseHelper.backup();
        }

        /// <summary>
        /// Create the Transactions table in the database
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        protected void btnCreateTransactionsTable_Click(object sender, EventArgs e)
        {
            TransactionsTable.create();
        }

        /// <summary>
        /// Create the Prices table in the database
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        protected void btnCreatePricesTable_Click(object sender, EventArgs e)
        {
            PricesTable.create();
        }

        /// <summary>
        /// Create the Calculated Statistics table in the database
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        protected void btnCreateCalculatedStatisticsTable_Click(object sender, EventArgs e)
        {
            CalculatedStatisticsTable.create();
        }
    }
}