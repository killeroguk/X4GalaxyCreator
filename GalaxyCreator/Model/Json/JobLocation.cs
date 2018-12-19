using System;
using System.Collections.Generic;

namespace GalaxyCreator.Model.Json
{
    public class JobLocation
    {
        private String LocationClass { get; set; } = "galaxy";
        private String Comparison { get; set; }
        private String Relation { get; set; }
        private String Macro { get; set; }
        private String RegionBasket { get; set; }
        private IList<Faction> Factions { get; set; }
    }
}
