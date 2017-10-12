using SecurityAnalysis.Core.FileSystem;
using System.Data.SQLite;
using System.IO;


namespace SecurityAnalysis.Core.Database
{
    public class DatabaseHelper
    {

        private static string getPath()
        {
            return Path.Combine(FileSystemHelper.getDataDirectory(), DATABASE_FILE_NAME);
        }

        private static string getBackupPath()
        {
            return Path.Combine(FileSystemHelper.getBackupDirectory(), DATABASE_FILE_NAME);
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

        public static void createTransactionsTable()
        {
            using (SQLiteConnection databaseConnection = open())
            {
                createTransactionsTable(databaseConnection);
            }
        }

        private static void createTransactionsTable(SQLiteConnection databaseConnection)
        {
            string sql = "create table " + TransactionsTable.NAME +
                         "(" +
                             TransactionsTable.COLUMN_ID + " integer PRIMARY KEY," +
                             TransactionsTable.COLUMN_DATE + " integer NOT NULL," +
                             TransactionsTable.COLUMN_TICKER + " text NOT NULL," +
                             TransactionsTable.COLUMN_SHARES + " integer NOT NULL," +
                             TransactionsTable.COLUMN_COST + " numeric NOT NULL" +
                          ")";

            executeNonQuery(sql, databaseConnection);
        }

        public static void createPricesTable()
        {
            using (SQLiteConnection databaseConnection = open())
            {
                createPricesTable(databaseConnection);
            }
        }

        private static void createPricesTable(SQLiteConnection databaseConnection)
        {
            string sql = "create table " + PricesTable.NAME +
                        "(" +
                            PricesTable.COLUMN_DATE + " integer NOT NULL," +
                            PricesTable.COLUMN_TICKER + " text NOT NULL," +
                            PricesTable.COLUMN_CLOSE + " numeric NOT NULL," +
                            "PRIMARY KEY(date, ticker)" +
                        ")";

            executeNonQuery(sql, databaseConnection);
        }

        public static void createCumulativeStatisticsTable()
        {
            using (SQLiteConnection databaseConnection = open())
            {
                createCumulativeStatisticsTable(databaseConnection);
            }
        }

        private static void createCumulativeStatisticsTable(SQLiteConnection databaseConnection)
        {
            string sql = "create table " + DatabaseConstants.CALCULATED_STATISTICS_TABLE +
                        "(" +
                            "date integer PRIMARY KEY," +
                            "portfolio_value" +
                        ")";

            executeNonQuery(sql, databaseConnection);
        }

        public static void executeNonQuery(string sql)
        {
            using (SQLiteConnection databaseConnection = open())
            {
                executeNonQuery(sql, databaseConnection);
            }
        }

        private static void executeNonQuery(string sql, SQLiteConnection databaseConnection)
        {
            using (SQLiteCommand command = new SQLiteCommand(sql, databaseConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        private const string DATABASE_FILE_NAME = "database.sqlite";
    }
}