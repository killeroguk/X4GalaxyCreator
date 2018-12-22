using System;

namespace GalaxyCreator.Model.Json
{
    [Serializable]
    public class Unit
    {
        public String Category { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
