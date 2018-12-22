using System;

namespace GalaxyCreator.Model.Json
{
    [Serializable]
    public class Connection
    {
        public String TargetClusterId { get; set; }
        public ConnectionType ConnectionType { get; set; }
        public CustomConnectionParameters Parameters { get; set; }
    }
}
