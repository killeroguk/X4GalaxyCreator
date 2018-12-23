using System;
using System.ComponentModel;

namespace GalaxyCreator.Model.Json
{
    public enum StationType
    {
        [Description("Shipyard")]
        SHIPYARD,
        [Description("Wharf")]
        WHARF,
        [Description("Equip")]
        EQUIP,
        [Description("Defence")]
        DEFENCE,
        [Description("Tradestation")]
        TRADE,
        [Description("Piratebase")]
        PIRATEBASE,
        [Description("Piratedock")]
        PIRATEDOCK,
        [Description("Teladi Ring")]
        TELADI_RING
    }
}
