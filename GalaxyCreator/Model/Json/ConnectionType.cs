using System;
using System.ComponentModel;

namespace GalaxyCreator.Model.Json
{
    public enum ConnectionType
    {
        [Description("N")]
        N,
        [Description("NE")]
        NE,
        [Description("SE")]
        SE,
        [Description("S")]
        S,
        [Description("SW")]
        SW,
        [Description("NW")]
        NW,
        [Description("Custom")]
        CUSTOM
    }
}
