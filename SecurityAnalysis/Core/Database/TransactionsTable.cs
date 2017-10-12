using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityAnalysis.Core.Database
{
    public static class TransactionsTable
    {
        #region public constants
        public const string NAME = "transactions";

        public const string COLUMN_ID = "id";
        public const string COLUMN_DATE = "date";
        public const string COLUMN_TICKER = "ticker";
        public const string COLUMN_SHARES = "shares";
        public const string COLUMN_COST = "cost";

        public const string PRIMARY_KEY = "(" + COLUMN_ID + ")";
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
                                                    COLUMN_ID + " integer PRIMARY KEY," +
                                                    COLUMN_DATE + " integer NOT NULL," +
                                                    COLUMN_TICKER + " text NOT NULL," +
                                                    COLUMN_SHARES + " integer NOT NULL," +
                                                    COLUMN_COST + " numeric NOT NULL" +
                                                ")";
        #endregion
    }
}