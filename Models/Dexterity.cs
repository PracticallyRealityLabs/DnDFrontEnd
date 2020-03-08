using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Dexterity
    {
        public Dexterity()
        {
            StatBlock = new HashSet<StatBlock>();
        }

        public int Dexterityid { get; set; }
        public bool? Dexsaveprof { get; set; }
        public int? Dexvalue { get; set; }
        public int? Acrobaticsid { get; set; }
        public int? Stealthid { get; set; }
        public int? Sleightid { get; set; }

        public virtual Acrobatics Acrobatics { get; set; }
        public virtual SleightOfHand Sleight { get; set; }
        public virtual Stealth Stealth { get; set; }
        public virtual ICollection<StatBlock> StatBlock { get; set; }
    }
}
