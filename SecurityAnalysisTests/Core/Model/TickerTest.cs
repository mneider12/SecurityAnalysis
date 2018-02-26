using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityAnalysis.Core.Model;

namespace SecurityAnalysisTests.Core.Model
{
    [TestClass]
    public class TickerTest
    {
        [TestMethod]
        public void EqualsTest()
        {
            Ticker amazonTicker = new Ticker("AMZN");
            Ticker googleTicker = new Ticker("GOOG");
            Ticker amazonTicker2 = new Ticker("AMZN");

            Assert.AreNotEqual(googleTicker, amazonTicker);
            Assert.AreEqual(amazonTicker2, amazonTicker);
        }
    }
}
