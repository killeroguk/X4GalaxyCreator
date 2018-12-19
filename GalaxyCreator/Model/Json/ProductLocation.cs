using System;
using System.Collections.Generic;

namespace GalaxyCreator.Model.Json
{
    class ProductLocation
    {
        public IList<Faction> SpawnLocations { get; set; }
        public IList<String> Wares { get; set; }
        public String EconomyMax { get; set; }
        public bool MaxBound { get; set; } = false;
        public String SunlightMin { get; set; }
        public String SunlightMax { get; set; }
        public String SecurityMin { get; set; }
        public bool Solitary { get; set; } = false;
    }
}
