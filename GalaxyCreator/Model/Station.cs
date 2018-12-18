using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyCreator.Model
{



    public class Station
    {
        public StationType Type { get; set; }
        public Race Race { get; set; }

        public Race Owner { get; set; }

        public Faction Faction { get; set; }


        public Station()
        {
        }
    }
}
