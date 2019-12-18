using epl.core.Interfaces;
using System.Collections.Generic;

namespace epl.core.Domain
{
    public class Deffects
    {
        public int ID { get; set; }
        public IList<string> WithGood { get; set; }
        public IList<string> WithMe { get; set; }
        public IList<string> WithOthers { get; set; }

        protected internal Deffects()
        {
            WithGood = new List<string>();
            WithMe = new List<string>();
            WithOthers = new List<string>();
        }
    }
}
