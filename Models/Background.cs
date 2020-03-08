using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Background
    {
        public int Backgroundid { get; set; }
        public string Description { get; set; }
        public string Bonds { get; set; }
        public string Flaws { get; set; }
        public string Ideals { get; set; }
        public string Traits { get; set; }
        public string Backgroundtype { get; set; }
        public int? Characterid { get; set; }

        public virtual PlayerCharacter Character { get; set; }
    }
}
