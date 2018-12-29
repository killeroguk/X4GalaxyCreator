using GalaxyCreator.Model.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GalaxyCreator.Util
{
    public class MilkAndCookies : IComparable
    {
        public Faction Faction { get; set; }
        public int Values { get; set; }

        public int CompareTo(object obj)
        {
            return this.Values.CompareTo(((MilkAndCookies)obj).Values);
            //throw new NotImplementedException();
            // return Values;
        }
    }

    public static class ClusterHelperFunctions
    {

        public static void ChooseClusterFillColour(Cluster cluster)
        {

            cluster.Polygon.Fill = Brushes.LightPink;

            var stationCount = cluster.Stations.GroupBy(s => s.Faction).Select(s => new MilkAndCookies() { Faction = s.Key, Values = s.Distinct().Count() }); ;

            var faction = stationCount.Max();
            if (faction != null)
            {
                switch (faction.Faction)
                {
                    case Faction.ARGON:
                        {
                            cluster.Polygon.Fill = Brushes.Blue;
                            break;
                        }
                    case Faction.PARANID:
                        {
                            cluster.Polygon.Fill = Brushes.Yellow;
                            break;
                        }
                    case Faction.TELADI:
                        {
                            cluster.Polygon.Fill = Brushes.Green;
                            break;
                        }
                    case Faction.XENON:
                        {
                            cluster.Polygon.Fill = Brushes.Red;
                            break;
                        }
                    case Faction.HOLYORDER:
                        {
                            cluster.Polygon.Fill = Brushes.GreenYellow;
                            break;
                        }
                    case Faction.ANTIGONE:
                        {
                            cluster.Polygon.Fill = Brushes.LightBlue;
                            break;
                        }
                    case Faction.ALLIANCE:
                        {
                            cluster.Polygon.Fill = Brushes.DarkCyan;
                            break;
                        }
                    case Faction.HATIKVAH:
                        {
                            cluster.Polygon.Fill = Brushes.IndianRed;
                            break;
                        }
                    case Faction.SCALEPLATE:
                        {
                            cluster.Polygon.Fill = Brushes.Peru;
                            break;
                        }
                      
                }
            }
        }

    }
}
