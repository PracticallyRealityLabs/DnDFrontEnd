using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class SpellListHasSpells
    {
        public int? SpellListHasSpellsid { get; set; }
        public int? SpellListId { get; set; }
        public int? Spellid { get; set; }

        public virtual Spells Spell { get; set; }
        public virtual SpellList SpellList { get; set; }
    }
}
