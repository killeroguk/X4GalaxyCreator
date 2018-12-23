using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GalaxyCreator.Model.Json
{
    public class JobCategory : ObservableObject
    {
        public Faction Faction { get; set; }
        public IList<Tag> Tags { get; set; } = new List<Tag>();
        public ShipSize ShipSize { get; set; }
    }
}
