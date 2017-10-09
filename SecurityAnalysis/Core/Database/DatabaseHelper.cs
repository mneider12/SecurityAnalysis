using System.Data.SQLite;
using System.IO;
using System.Web;


namespace SecurityAnalysis.Core.Database
{
    public class DatabaseHelper
    {

        private static string getPath()
        {
            string databaseFilePath = Path.Combine("~", DatabaseConstants.DATABASE_DIRECTORY, DatabaseConstants.DATABASE_FILE_NAME);
            return HttpContext.Current.Server.MapPath(databaseFilePath);
        }

        public static SQLiteConnection open()
        {
            SQLiteConnection databaseConnection = new SQLiteConnection("Data Source=" + getPath());
            databaseConnection.Open();

            return databaseConnection;
        }

        public static void create()
        {
            string directoryFilePath = Path.Combine("~", DatabaseConstants.DATABASE_DIRECTORY);
            directoryFilePath = HttpContext.Current.Server.MapPath(directoryFilePath);
            Directory.CreateDirectory(directoryFilePath);      // Make sure the database directory exists

            string databaseFilePath = getPath();
            SQLiteConnection.CreateFile(databaseFilePath);

            using (SQLiteConnection databasebConnection = open())
            {
                createTransactionsTable(databasebConnection);
                createPricesTable(databasebConnection);
            }
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