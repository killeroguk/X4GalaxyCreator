using System;

namespace GalaxyCreator.Model.Json
{
    public class SpaceObject
    {
        public SpaceObjectType Type { get; set; }
        public String ClusterId { get; set; }
        public String ShipMacro { get; set; }
        public Int64 X { get; set; }
        public Int64 Y { get; set; }
        public Int64 Z { get; set; }
        public int Yaw { get; set; }
        public int Pitch { get; set; }
        public int Roll { get; set; }
    }
}
