using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityAnalysis.Core.Model
{
    public class StockTransaction : Transaction
    {
        public StockTransaction(DateTime date, Ticker ticker, int numberOfShares, decimal amount) : base(date, amount)
        {
            Ticker = ticker;
            NumberOfShares = numberOfShares;
        }

        public Ticker Ticker { get; set; }
        public int NumberOfShares { get; set; }
    }
}