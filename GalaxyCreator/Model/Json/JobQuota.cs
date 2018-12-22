using System;

namespace GalaxyCreator.Model.Json
{
    [Serializable]
    public class JobQuota
    {
        public Int16 Galaxy { get; set; }
        public Int16 MaxGalaxy { get; set; }
        public Int16 Cluster { get; set; }
        public Int16 Sector { get; set; }
        public Int16 Wing { get; set; }
        public Int16 Variation { get; set; }
        public Int16 Station { get; set; }
    }
}
