using System;

namespace GalaxyCreator.Model.Json
{
    [Serializable]
    public enum Tag
    {
        FACTIONLOGIC, FREIGHTER, TRADER,
        CONTAINER, MINER, LIQUID, SOLID,
        MILITARY, CARRIER, DESTROYER, FRIGATE,
        FIGHTER, HEAVY, SCOUT, POLICE, LIGHT,
        MEDIUM, SELECTION, DEEPSPACE, BUILDER,
        RESUPPLIER, MIXED, CORVETTE, PLUNDERER,
        ESCORT
    }
}
