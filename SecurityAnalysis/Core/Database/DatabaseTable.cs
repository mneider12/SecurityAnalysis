using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityAnalysis.Core.Database
{
    interface DatabaseTable
    {
        string NAME { get; }
        string CREATE_TABLE_SQL { get; }

    }
}
