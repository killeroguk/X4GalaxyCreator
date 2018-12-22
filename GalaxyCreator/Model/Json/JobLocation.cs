using System;
using System.Collections.Generic;

namespace GalaxyCreator.Model.Json
{
    [Serializable]
    public class JobLocation
    {
        public String LocationClass { get; set; } = "galaxy";
        public ComparisonType Comparison { get; set; }
        public RelationType Relation { get; set; }
        public String Macro { get; set; }
        public String RegionBasket { get; set; }
        public IList<Faction> Factions { get; set; }
    }
}
