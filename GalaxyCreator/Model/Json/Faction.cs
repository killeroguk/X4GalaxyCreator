using System;
using System.ComponentModel;

namespace GalaxyCreator.Model.Json
{
    public enum Faction
    {
        [Description("Player")]
        PLAYER,
        [Description("Argon")]
        ARGON,
        [Description("Antigone")]
        ANTIGONE,
        [Description("Hatikvah")]
        HATIKVAH,
        [Description("Paranid")]
        PARANID,
        [Description("Holyorder")]
        HOLYORDER,
        [Description("Alliance")]
        ALLIANCE,
        [Description("Teladi")]
        TELADI,
        [Description("Ministry")]
        MINISTRY,
        [Description("Scaleplate")]
        SCALEPLATE,
        [Description("XENON")]
        XENON,
        [Description("Player Owner")]
        PLAYEROWNER,
        [Description("Ownerless")]
        OWNERLESS,
        [Description("None")]
        NONE
    }
}
