using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class SpellList
    {
        public SpellList()
        {
            SpellListHasSpells = new HashSet<SpellListHasSpells>();
        }

        public int Spelllistid { get; set; }
        public int? Characterid { get; set; }

        public virtual PlayerCharacter Character { get; set; }
        public virtual ICollection<SpellListHasSpells> SpellListHasSpells { get; set; }
    }
}
