﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityAnalysis.Core.Database
{
    public static class CashTransactions
    {
        #region public constants
        /// <summary>
        /// Table name
        /// </summary>
        public const string NAME = "cash_transactions";
        #region column names
        /// <summary>
        /// Unique transaction ID
        /// </summary>
        public const string COLUMN_ID = "id";
        /// <summary>
        /// Transaction date
        /// </summary>
        public const string COLUMN_DATE = "date";
        /// <summary>
        /// Transaction Amount
        /// </summary>
        public const string COLUMN_AMOUNT = "amount";
        #endregion
        /// <summary>
        /// Primary key including parentheses
        /// </summary>
        public const string PRIMARY_KEY = "(" + COLUMN_ID + ")";
        #endregion

        #region public methods
        /// <summary>
        /// Create the table
        /// </summary>
        public static void create()
        {
            DatabaseHelper.executeNonQuery(CREATE_TABLE);
        }
        #endregion
        #region private constants
        /// <summary>
        /// SQL command to create the table
        /// </summary>
        private const string CREATE_TABLE = "create table " + NAME +
                                                "(" +
                                                    COLUMN_ID + "integer PRIMARY KEY," +
                                                    COLUMN_DATE + "integer NOT NULL," +
                                                    COLUMN_AMOUNT + "numeric NOT NULL" +
                                                ")";
        #endregion
    }
}