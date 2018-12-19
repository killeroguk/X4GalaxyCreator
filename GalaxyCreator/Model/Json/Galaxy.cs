using System;
using System.Collections.Generic;

namespace GalaxyCreator.Model.Json
{
    public class Galaxy
    {
        public long Seed { get; set; }
        public String GalaxyName { get; set; }
        public String GalaxyPrefix { get; set; }
        public GalaxyOptions GalaxyOptions { get; set; }
        public String Description { get; set; }
        public String Author { get; set; }
        public String Version { get; set; }
        public String Date { get; set; }
        public String Save { get; set; }
        public String StarterZoneName { get; set; }
        public int MinRandomBelts { get; set; }
        public int MaxRandomBelts { get; set; }
        public IList<Cluster> Clusters { get; set; }
        public IList<Product> Products { get; set; }
        public IList<Job> Jobs { get; set; }

    }
}
