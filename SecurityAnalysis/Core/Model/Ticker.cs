using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityAnalysis.Core.Model
{
    public class Ticker
    {
        public Ticker(string name)
        {
            Name = name;
        }
        public string Name { get; private set;  }

        public override bool Equals(Object obj)
        {
            Ticker otherTicker = obj as Ticker;
            if (otherTicker == null)
            {
                return false;
            }
            else
            {
                return Name.Equals(otherTicker.Name);
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}