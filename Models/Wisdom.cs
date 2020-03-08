using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Wisdom
    {
        public Wisdom()
        {
            StatBlock = new HashSet<StatBlock>();
        }

        public int Wisdomid { get; set; }
        public bool? Wissaveprof { get; set; }
        public int? Wisvalue { get; set; }
        public int? Animalhandid { get; set; }
        public int? Perceptionid { get; set; }
        public int? Insightid { get; set; }
        public int? Survivalid { get; set; }

        public virtual AnimalHandling Animalhand { get; set; }
        public virtual Insight Insight { get; set; }
        public virtual Perception Perception { get; set; }
        public virtual Survival Survival { get; set; }
        public virtual ICollection<StatBlock> StatBlock { get; set; }
    }
}
