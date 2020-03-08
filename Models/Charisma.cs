using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Charisma
    {
        public Charisma()
        {
            StatBlock = new HashSet<StatBlock>();
        }

        public int Charismaid { get; set; }
        public bool? Chasaveprof { get; set; }
        public int? Chavalue { get; set; }
        public int? Persuasionid { get; set; }
        public int? Performanceid { get; set; }
        public int? Deceptionid { get; set; }
        public int? Intimidationid { get; set; }

        public virtual Deception Deception { get; set; }
        public virtual Intimidation Intimidation { get; set; }
        public virtual Performance Performance { get; set; }
        public virtual Persuasion Persuasion { get; set; }
        public virtual ICollection<StatBlock> StatBlock { get; set; }
    }
}
