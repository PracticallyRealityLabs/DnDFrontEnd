using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Strength
    {
        public Strength()
        {
            StatBlock = new HashSet<StatBlock>();
        }

        public int Strengthid { get; set; }
        public bool? Strsaveprof { get; set; }
        public int? Strvalue { get; set; }
        public int? Athleticsid { get; set; }

        public virtual Athletics Athletics { get; set; }
        public virtual ICollection<StatBlock> StatBlock { get; set; }
    }
}
