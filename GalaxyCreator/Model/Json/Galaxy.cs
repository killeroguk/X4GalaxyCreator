using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GalaxyCreator.Model.Json
{
    public class Galaxy
    {
        public long Seed { get; set; }
        public String GalaxyName { get; set; }
        public String GalaxyPrefix { get; set; }
        public GalaxyOptions GalaxyOptions { get; set; } = new GalaxyOptions();
        public String Description { get; set; }
        public String Author { get; set; }
        public String Version { get; set; }
        public String Date { get; set; }
        public String Save { get; set; }
        public int MinRandomBelts { get; set; } = 3;
        public int MaxRandomBelts { get; set; } = 5;
        public IList<Cluster> Clusters { get; set; }= new List<Cluster>();
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Job> Jobs { get; set; } = new ObservableCollection<Job>();

        [JsonIgnore]
        public ObservableCollection<CanvasConnection> CanvasConnections { get; set; }

        public Galaxy()
        {
            CanvasConnections = new ObservableCollection<CanvasConnection>();
        }

    }
}