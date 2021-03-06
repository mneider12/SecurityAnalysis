﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityAnalysis.Core.Database
{
    /// <summary>
    /// Methods for manipulating the calculated_statistics table
    /// </summary>
    public static class CalculatedStatisticsTable
    {
        #region public constants
        /// <summary>
        /// Name of the table
        /// </summary>
        public const string NAME = "calculated_statistics";
        #region columns
        /// <summary>
        /// Date that calculated statistics are valid as of
        /// </summary>
        public const string COLUMN_DATE = "date";
        /// <summary>
        /// Value of portfolio
        /// </summary>
        public const string COLUMN_PORTFOLIO_VALUE = "portfolio_value";
        #endregion
        /// <summary>
        /// Table primary key. Includes parentheses.
        /// </summary>
        public const string PRIMARY_KEY = "(" + COLUMN_DATE + ")";
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
                                                    COLUMN_DATE + " integer PRIMARY KEY," +
                                                    COLUMN_PORTFOLIO_VALUE + "numeric" +
                                                ")";
        #endregion
    }
}