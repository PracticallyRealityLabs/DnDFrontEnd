using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Features
    {
        public int Featuresid { get; set; }
        public string Description { get; set; }
        public string Aquiredfrom { get; set; }
        public int? CaharacterId { get; set; }

        public virtual PlayerCharacter Caharacter { get; set; }
    }
}
