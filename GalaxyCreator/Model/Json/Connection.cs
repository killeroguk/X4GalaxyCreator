using System;

namespace GalaxyCreator.Model.Json
{
    public class Connection
    {
        public String TargetClusterId { get; set; }
        public ConnectionType ConnectionType { get; set; }
        public CustomConnectionParameters Parameters { get; set; }
    }
}
