using System;
using System.ComponentModel;

namespace GalaxyCreator.Model.Json
{
    public enum SpaceObjectType
    {
        [Description("Claim")]
        CLAIM,
        [Description("Landmark")]
        LANDMARK,
        [Description("Anomaly")]
        ANOMALY
    }
}
