using epl.core.Interfaces;
using System.Collections.Generic;

namespace epl.core.Domain.ProgramOfLife
{
    public class MainDeffect : IEntity
    {
        public int ID { get; set; }
        public IList<string> WithGood { get; set; }
        public IList<string> WithMe { get; set; }
        public IList<string> WithOthers { get; set; }

        public MainDeffect()
        {
            WithGood = new List<string>();
            WithMe = new List<string>();
            WithOthers = new List<string>();
        }
    }
}
