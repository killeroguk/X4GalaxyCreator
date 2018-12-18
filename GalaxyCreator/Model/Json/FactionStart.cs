using System;

namespace GalaxyCreator.Model.Json
{
    class FactionStart
    {
        public String ClusterId { get; set; }
        public Faction Faction { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String PlayerName { get; set; }
    }
}
