
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace GalaxyCreator.Model
{
    public class Sector
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Music { get; set; }
        public string Sunlight { get; set; }
        public string Economy { get; set; }
        public string Security { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Backdrop { get; set; }
        public bool Gamestart { get; set; }
        public bool IsEnabled { get; set; }

        public Hex Hex { get; set; }

        // public List<Connections> {get;set;}

        public ObservableCollection<Belt> Belts {get;set;}

        public ObservableCollection<Station> Stations {get;set;}


        public Sector(int x, int y, double size)
        {

            Id = Guid.NewGuid();
            Name = "HAPPY SECTOR";
            Hex = new Hex(x, y, size);
            Hex.CreateShape(Id);

            Stations = new ObservableCollection<Station>();
            Belts = new ObservableCollection<Belt>();




        }

       
    }
}
