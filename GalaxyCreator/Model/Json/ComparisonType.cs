using System;
using System.ComponentModel;

namespace GalaxyCreator.Model.Json
{
    public enum ComparisonType
    {
        [Description("Not")]
        not,
        [Description("Lt")]
        lt,
        [Description("Exzact")]
        exact,
        [Description("Ge")]
        ge
    }
}
