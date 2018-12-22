using System;

namespace GalaxyCreator.Model.Json
{
    public class Product
    {
        public String Id { get; set; }
        public String Ware { get; set; }
        public Int16 GalaxyQuota { get; set; }
        public Int16 ZoneQuota { get; set; }
        public Int16 SectorQuota { get; set; }
        public Int16 ClusterQuota { get; set; }
        public Race Race { get; set; }
        public Faction Owner { get; set; }
        public ProductLocation LocationInfo { get; set; }
    }
}
