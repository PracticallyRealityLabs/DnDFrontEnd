using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class StatBlock
    {
        public int Statblockid { get; set; }
        public int? Basehp { get; set; }
        public int? Speed { get; set; }
        public int? Level { get; set; }
        public int? Passiveperception { get; set; }
        public string Vision { get; set; }
        public int? Characterid { get; set; }
        public int? Strengthid { get; set; }
        public int? Dexterityid { get; set; }
        public int? Constitutionid { get; set; }
        public int? Intelligenceid { get; set; }
        public int? Wisdomid { get; set; }
        public int? Charismaid { get; set; }

        public virtual PlayerCharacter Character { get; set; }
        public virtual Charisma Charisma { get; set; }
        public virtual Constitution Constitution { get; set; }
        public virtual Dexterity Dexterity { get; set; }
        public virtual Intelligence Intelligence { get; set; }
        public virtual Strength Strength { get; set; }
        public virtual Wisdom Wisdom { get; set; }
    }
}
