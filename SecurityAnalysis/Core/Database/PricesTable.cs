using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityAnalysis.Core.Database
{
    public static class PricesTable
    {
        #region public constants
        public const string NAME = "prices";

        public const string COLUMN_DATE = "date";
        public const string COLUMN_TICKER = "ticker";
        public const string COLUMN_CLOSE = "close";

        public const string PRIMARY_KEY = "(" + COLUMN_DATE + "," + COLUMN_TICKER + ")";
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
                                                    COLUMN_DATE + " integer NOT NULL," +
                                                    COLUMN_TICKER + " text NOT NULL," +
                                                    COLUMN_CLOSE + " numeric NOT NULL," +
                                                    "PRIMARY KEY" + PRIMARY_KEY + 
                                                ")";
        #endregion
    }
}