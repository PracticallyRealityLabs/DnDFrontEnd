using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Constitution
    {
        public Constitution()
        {
            StatBlock = new HashSet<StatBlock>();
        }

        public int Constitutionid { get; set; }
        public bool? Consaveprof { get; set; }
        public int? Convalue { get; set; }

        public virtual ICollection<StatBlock> StatBlock { get; set; }
    }
}
