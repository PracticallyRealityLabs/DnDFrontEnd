using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Intelligence
    {
        public Intelligence()
        {
            StatBlock = new HashSet<StatBlock>();
        }

        public int Intelligenceid { get; set; }
        public int? Intvalue { get; set; }
        public bool? Intsaveprof { get; set; }
        public int? Investigationid { get; set; }
        public int? Historyid { get; set; }
        public int? Arcanaid { get; set; }
        public int? Natureid { get; set; }
        public int? Religionid { get; set; }

        public virtual Arcana Arcana { get; set; }
        public virtual History History { get; set; }
        public virtual Investigation Investigation { get; set; }
        public virtual Nature Nature { get; set; }
        public virtual Religion Religion { get; set; }
        public virtual ICollection<StatBlock> StatBlock { get; set; }
    }
}
