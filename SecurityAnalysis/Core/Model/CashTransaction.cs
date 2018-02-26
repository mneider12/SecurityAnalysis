using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityAnalysis.Core.Model
{
    public class CashTransaction : Transaction
    {
        public CashTransaction(DateTime date, decimal amount) : base(date, amount)
        {

        }
    }
}
