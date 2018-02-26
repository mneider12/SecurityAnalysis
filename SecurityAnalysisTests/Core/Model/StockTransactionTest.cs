using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityAnalysis.Core.Model;

namespace SecurityAnalysisTests.Core.Model
{
    [TestClass]
    public class StockTransactionTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            DateTime date = new DateTime(2000, 1, 1);
            Ticker ticker = new Ticker("AMZN");
            int numberOfShares = 100;
            decimal amount = 50000.30M;
            StockTransaction transaction = new StockTransaction(date, ticker, numberOfShares, amount);

            Assert.AreEqual(date, transaction.Date);
            Assert.AreEqual(ticker, transaction.Ticker);
            Assert.AreEqual(numberOfShares, transaction.NumberOfShares);
            Assert.AreEqual(amount, transaction.Amount);
        }
    }
}
