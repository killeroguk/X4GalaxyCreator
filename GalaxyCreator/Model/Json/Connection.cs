using GalaSoft.MvvmLight;
using System;
using System.Linq;

namespace GalaxyCreator.Model.Json
{
    public class Connection:ObservableObject
    {
        private String _targetClusterId;
        public String TargetClusterId
        {
            get
            {
                return _targetClusterId;
            }
            set {
                Set(ref _targetClusterId, value);

                MainData.GetGalaxyMap().CanvasConnections.Add(new CanvasConnection(_targetClusterId, MainData.SelectedMapCluster.Id, ConnectionType);

            }
        }

        private ConnectionType _connectionType;
        public ConnectionType ConnectionType
        {
            get { return _connectionType; }
            set {
                Set(ref _connectionType, value);
            }
        }

        public CustomConnectionParameters _parameters;
        public CustomConnectionParameters Parameters
        {
            get { return _parameters; }
            set {
                Set(ref _parameters, value);
            }
        }
    }
}
