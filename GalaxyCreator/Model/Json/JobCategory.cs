using System.Collections.Generic;

namespace GalaxyCreator.Model.Json
{
    public class JobCategory
    {
        public Faction Faction { get; set; }
        public IList<Tag> Tags { get; set; }
        public ShipSize ShipSize { get; set; }
    }
}
