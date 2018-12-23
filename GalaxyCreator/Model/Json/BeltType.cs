using System;
using System.ComponentModel;

namespace GalaxyCreator.Model.Json
{
    public enum BeltType
    {
        [Description("Ore")]
        ORE,
        [Description("Ice")]
        ICE,
        [Description("Hydrogen")]
        HYDROGEN,
        [Description("Helium")]
        HELIUM,
        [Description("Methane")]
        METHANE,
        [Description("Nvidium")]
        NVIDIUM
    }
}
