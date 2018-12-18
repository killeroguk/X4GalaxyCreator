using System;
using System.Collections.Generic;

namespace GalaxyCreator.Model.Json
{
    class Job
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public Boolean StartActive { get; set; }
        public Boolean Disabled { get; set; }
        public Boolean Rebuild { get; set; }
        public Boolean Commandeerable { get; set; }
        public Boolean Subordinate { get; set; }
        public bool Buildatshipyard { get; set; } = true;
        public JobLocation JobLocation { get; set; }
        public JobCategory JobCategory { get; set; }
        public JobQuota JobQuota { get; set; }
        public IList<JobOrder> Orders { get; set; }
        public String Basket { get; set; }
        public String Encounters { get; set; }
        public String Time { get; set; }
        public Ship Ship { get; set; }
        public IList<String> Subordinates { get; set; }
    }
}
