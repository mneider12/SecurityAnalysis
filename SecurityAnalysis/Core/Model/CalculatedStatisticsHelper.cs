using SecurityAnalysis.Core.Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace SecurityAnalysis.Core.Model
{
    public static class CalculatedStatisticsHelper
    {
        public static void calculateStatistics(DateTime date)
        {

        }

        public static void calculatePortfolioValue(DateTime date)
        {
            Decimal lastValue;
            DateTime lastDate;

            if (getLastPortfolioValue(date, out lastValue, out lastDate))
            {

            }
        }

        /*private static Decimal getPortfolioValue(DateTime date, Decimal lastValue, DateTime lastDate)
        {
            string sql = "SELECT " +
                            "SUM(portfolio_value) " +
                         "FROM " + DatabaseConstants.TRANSACTIONS_TABLE
        }*/

        private static bool getLastPortfolioValue(DateTime date, out Decimal lastValue, out DateTime lastDate)
        {
            string sql = "SELECT TOP 1 " +
                            "date, portfolio_value " +
                         "FROM " + DatabaseConstants.CALCULATED_STATISTICS_TABLE +
                        " WHERE " +
                            "date <= " + date.Ticks;
            bool failed = false;

            using (SQLiteConnection databaseConnection = DatabaseHelper.open())
            {
                using (SQLiteCommand getLastPortfolioValueCommand = new SQLiteCommand(sql, databaseConnection))
                {
                    using (SQLiteDataReader lastPortfolioValueReader = getLastPortfolioValueCommand.ExecuteReader()) 
                    {
                        lastPortfolioValueReader.Read();    // should only be one result

                        if (!Decimal.TryParse((string)lastPortfolioValueReader["portfolio_value"], out lastValue))
                        {
                            failed = true;
                        }

                        if (!DateTime.TryParse((string)lastPortfolioValueReader["date"], out lastDate))
                        {
                            failed = true;
                        }
                    }
                    
                }
            }

            return !failed;
        }
    }
}