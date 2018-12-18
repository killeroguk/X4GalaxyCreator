using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GalaxyCreator.Model
{
    public class SectorGrid
    {

        public List<Sector> Sectors = new List<Sector>();


        public SectorGrid( Canvas canvas,  int rowCount, int colCount, double size)
        {
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    Sector sector = new Sector(row, col,size);

                    Sectors.Add(sector);

                    MainData.AddShapeToList(sector.Hex.canvasElement);

                }
            }


        }

    }
}
