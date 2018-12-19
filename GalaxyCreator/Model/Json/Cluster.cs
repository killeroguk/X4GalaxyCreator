using System;
using System.Collections.Generic;

namespace GalaxyCreator.Model.Json
{
    class Cluster
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Music { get; set; }
        public String Sunlight { get; set; }
        public String Economy { get; set; }
        public String Security { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public String Backdrop { get; set; }
        public bool NoBelts { get; set; } = false;
        public Faction FactionHq { get; set; }
        public FactionStart FactionStart { get; set; }
        public IList<Connection> Connections { get; set; }
        public IList<Belt> Belts { get; set; }
        public IList<Station> Stations { get; set; }
        public IList<SpaceObject> SpaceObjects { get; set; }
    }
}
