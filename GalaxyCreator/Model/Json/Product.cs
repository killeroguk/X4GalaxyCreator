using GalaSoft.MvvmLight;
using System;

namespace GalaxyCreator.Model.Json
{
    public class Product : ObservableObject
    {
        private String _id;
        public String Id
        {
            get { return _id; }
            set
            {
                Set(ref _id, value);
            }
        }

        private String _ware;
        public String Ware
        {
            get { return _ware; }
            set
            {
                Set(ref _ware, value);
            }
        }

        private Int16 _galaxyQuota;
        public Int16 GalaxyQuota
        {
            get { return _galaxyQuota; }
            set
            {
                Set(ref _galaxyQuota, value);
            }
        }

        private Int16 _clusterQuota;
        public Int16 ClusterQuota
        {
            get { return _clusterQuota; }
            set
            {
                Set(ref _clusterQuota, value);
            }
        }

        private Int16 _sectorQuota;
        public Int16 SectorQuota
        {
            get { return _sectorQuota; }
            set
            {
                Set(ref _sectorQuota, value);
            }
        }

        private Int16 _zoneQuota;
        public Int16 ZoneQuota
        {
            get { return _zoneQuota; }
            set
            {
                Set(ref _zoneQuota, value);
            }
        }

        private Race _race;
        public Race Race
        {
            get { return _race; }
            set
            {
                Set(ref _race, value);
            }
        }

        private Faction _owner;
        public Faction Owner
        {
            get { return _owner; }
            set
            {
                Set(ref _owner, value);
            }
        }

        public ProductLocation LocationInfo { get; set; }
    }
}
