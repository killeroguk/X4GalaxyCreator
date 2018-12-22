using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GalaxyCreator.Model.Json
{
    [Serializable]
    public class Galaxy
    {
        public long Seed { get; set; }
        public String GalaxyName { get; set; }
        public String GalaxyPrefix { get; set; }
        public GalaxyOptions GalaxyOptions { get; set; }
        public String Description { get; set; }
        public String Author { get; set; }
        public String Version { get; set; }
        public String Date { get; set; }
        public String Save { get; set; }
        public String StarterZoneName { get; set; }
        public int MinRandomBelts { get; set; }
        public int MaxRandomBelts { get; set; }
        public IList<Cluster> Clusters { get; set; }
        public IList<Product> Products { get; set; }
        public ObservableCollection<Job> Jobs { get; set; }

        public Galaxy(int rowCount, int colCount, double hexSize)
        {

            Clusters = new List<Cluster>();
            Products = new List<Product>();
            Jobs = new ObservableCollection<Job>();

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    Cluster cluster = new Cluster(row, col, hexSize, true);
                    Clusters.Add(cluster);

                }
            }
        }

    }
}
