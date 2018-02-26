using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityAnalysis.Core.Model
{
    public class Withdrawl : CashTransaction
    {
        public Withdrawl(DateTime date, decimal amount) : base(date, amount) { }
    }
}