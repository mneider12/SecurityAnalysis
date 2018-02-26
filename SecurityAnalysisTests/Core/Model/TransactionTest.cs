using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityAnalysis.Core.Model;

namespace SecurityAnalysisTests.Core.Model
{
    [TestClass]
    public class TransactionTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            DateTime date = new DateTime(2000, 1, 1);
            Decimal amount = 100.50M;

            Transaction transaction = new Transaction(date, amount);
            Assert.AreEqual(date, transaction.Date);
        }
    }
}
