using System;
using System.Collections.Generic;

namespace GalaxyCreator.Model.Json
{
    public class Ship
    {
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<Faction> Factions { get; set; } = new List<Faction>();
        public ShipSize Size { get; set; }
        public String LevelMin { get; set; }
        public String LevelMax { get; set; }
        public bool Overridenpc { get; set; } = true;
        public Cargo Cargo { get; set; }
        public IList<Unit> Units { get; set; } = new List<Unit>();
    }
}
