using GalaSoft.MvvmLight;
using GalaxyCreator.Util;
using System;

namespace GalaxyCreator.Model.Json
{
    public class Station:ObservableObject
    {

        private StationType _type;
        public StationType Type {
            get {return _type; }
            set {
                Set(ref _type, value);

                if ( MainData.SelectedMapCluster != null)
                    ClusterHelperFunctions.ChooseClusterFillColour(MainData.SelectedMapCluster);
            }
        }

        private Race _race;
        public Race Race {
            get { return _race; }
            set {
                Set(ref _race, value);

                if (MainData.SelectedMapCluster != null)
                    ClusterHelperFunctions.ChooseClusterFillColour(MainData.SelectedMapCluster);
            }
        }

        private Faction _owner;
        public Faction Owner {
            get { return _owner; }
            set {
                Set(ref _owner, value);

                if (MainData.SelectedMapCluster != null)
                    ClusterHelperFunctions.ChooseClusterFillColour(MainData.SelectedMapCluster);
            }
        }

        private Faction _faction;
        public Faction Faction {
            get { return _faction; }
            set {
                Set(ref _faction, value);

                if (MainData.SelectedMapCluster != null)
                    ClusterHelperFunctions.ChooseClusterFillColour(MainData.SelectedMapCluster);
            }
        }

    }
}
