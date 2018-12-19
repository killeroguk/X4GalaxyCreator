using System;

namespace GalaxyCreator.Model.Json
{
    public class Cargo
    {
        public bool Multiple { get; set; } = true;
        public int Min { get; set; } = 0;
        public int Max { get; set; } = 100;
        public String Profile { get; set; }
    }
}
