using System;
using System.Collections.Generic;

namespace GalaxyCreator.Model.Json
{
    [Serializable]
    public class JobOrder
    {
        public String Order { get; set; }
        public bool DefaultOrder { get; set; } = true;
        public IList<OrderParameter> Parameters { get; set; }
    }
}
