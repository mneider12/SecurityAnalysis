using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityAnalysis.Core.Database
{
    public static class CalculatedStatisticsTable
    {
        #region public constants
        public const string NAME = "calculated_statistics";

        public const string COLUMN_DATE = "date";
        public const string COLUMN_PORTFOLIO_VALUE = "portfolio_value";

        public const string PRIMARY_KEY = "(" + COLUMN_DATE + ")";
        #endregion

        #region public methods
        public static void create()
        {
            DatabaseHelper.executeNonQuery(CREATE_TABLE);
        }
        #endregion

        #region private constants
        private const string CREATE_TABLE = "create table " + NAME +
                                                "(" +
                                                    COLUMN_DATE + " integer PRIMARY KEY," +
                                                    COLUMN_PORTFOLIO_VALUE + "numeric" +
                                                ")";
        #endregion
    }
}