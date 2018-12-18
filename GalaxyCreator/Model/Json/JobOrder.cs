using System;
using System.Collections.Generic;

namespace GalaxyCreator.Model.Json
{
    class JobOrder
    {
        public String Order { get; set; }
        public bool DefaultOrder { get; set; } = true;
        public IList<OrderParameter> parameters { get; set; }
    }
}
