using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Spells
    {
        public Spells()
        {
            SpellListHasSpells = new HashSet<SpellListHasSpells>();
        }

        public int Spellsid { get; set; }
        public string Spellname { get; set; }
        public string School { get; set; }
        public int? Level { get; set; }
        public int? Range { get; set; }
        public string Components { get; set; }
        public int? Duration { get; set; }
        public int? Description { get; set; }
        public bool? Concentration { get; set; }

        public virtual ICollection<SpellListHasSpells> SpellListHasSpells { get; set; }
    }
}
