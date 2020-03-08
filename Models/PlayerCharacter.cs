using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class PlayerCharacter
    {
        public PlayerCharacter()
        {
            Background = new HashSet<Background>();
            Features = new HashSet<Features>();
            Inventory = new HashSet<Inventory>();
            SpellList = new HashSet<SpellList>();
            StatBlock = new HashSet<StatBlock>();
        }

        public int PlayerCharacterid { get; set; }
        public string Charactername { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }
        public string Alignment { get; set; }
        public string Languages { get; set; }
        public int? Campaignid { get; set; }
        public int? Userid { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Background> Background { get; set; }
        public virtual ICollection<Features> Features { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<SpellList> SpellList { get; set; }
        public virtual ICollection<StatBlock> StatBlock { get; set; }
    }
}
