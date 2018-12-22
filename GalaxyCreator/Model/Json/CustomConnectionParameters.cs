using System;

namespace GalaxyCreator.Model.Json
{
    [Serializable]
    public class CustomConnectionParameters
    {
        public int StartRotation { get; set; }
        public int StartPositionX { get; set; }
        public int StartPositionY { get; set; }
        public int EndRotation { get; set; }
        public int EndPositionX { get; set; }
        public int EndPositionY { get; set; }
    }
}
