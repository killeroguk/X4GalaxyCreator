using System;
using System.ComponentModel;

namespace GalaxyCreator.Model.Json
{
    public enum RelationType
    {
        [Description("Member")]
        member,
        [Description("Self")]
        self,
        [Description("Neural")]
        neutral,
        [Description("Friend")]
        friend
    }
}
