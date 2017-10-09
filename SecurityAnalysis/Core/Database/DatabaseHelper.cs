using SecurityAnalysis.Core.FileSystem;
using System.Data.SQLite;
using System.IO;
using System.Web;


namespace SecurityAnalysis.Core.Database
{
    public class DatabaseHelper
    {

        private static string getPath()
        {
            return Path.Combine(FileSystemHelper.getDataDirectory(), DatabaseConstants.DATABASE_FILE_NAME);
        }

        private static string getBackupPath()
        {
            return Path.Combine(FileSystemHelper.getBackupDirectory(), DatabaseConstants.DATABASE_FILE_NAME);
        }

        public static SQLiteConnection open()
        {
            SQLiteConnection databaseConnection = new SQLiteConnection("Data Source=" + getPath());
            databaseConnection.Open();

            return databaseConnection;
        }

        public static void create()
        {
            string databaseFilePath = getPath();
            if (!File.Exists(databaseFilePath))  //database can't already exist
            {
                SQLiteConnection.CreateFile(databaseFilePath);

                using (SQLiteConnection databasebConnection = open())
                {
                    createTransactionsTable(databasebConnection);
                    createPricesTable(databasebConnection);
                }
            }
        }

        public static void delete()
        {
            File.Delete(getPath());
        }

        public static void backup()
        {
            string backupFilePath = getBackupPath();


            File.Delete(backupFilePath);
            File.Copy(getPath(), backupFilePath);
        }

        private static void createTransactionsTable(SQLiteConnection databaseConnection)
        {
            string sql = "create table " + DatabaseConstants.TRANACTIONS_TABLE +
                         "(" +
                             "id integer PRIMARY KEY," +
                             "date integer NOT NULL," +
                             "ticker text NOT NULL," +
                             "shares integer NOT NULL," +
                             "cost numeric NOT NULL" +
                          ")";

            executeNonQuery(sql, databaseConnection);
        }

        private static void createPricesTable(SQLiteConnection databaseConnection)
        {
            string sql = "create table " + DatabaseConstants.PRICES_TABLE +
                        "(" +
                            "date integer PRIMARY KEY," +
                            "ticker text PRIMARY KEY," +
                            "close numeric NOT NULL" +
                        ")";

            executeNonQuery(sql, databaseConnection);
        }

        private static void executeNonQuery(string sql, SQLiteConnection databaseConnection)
        {
            using (SQLiteCommand command = new SQLiteCommand(sql, databaseConnection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}