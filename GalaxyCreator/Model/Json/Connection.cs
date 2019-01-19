using GalaSoft.MvvmLight;
using GalaxyCreator.Model.CanvasModel;
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

                if (MainData.GetGalaxyMap() != null)
                {
                    var oldConnection = MainData.GetGalaxyMap().CanvasConnections.FirstOrDefault(c => c.ConnectionId1 == _targetClusterId && c.ConnectionId2 == MainData.SelectedMapCluster.Id);

                    if (oldConnection != null)
                        MainData.RemoveConnectionFromCanvas(oldConnection);
                }

                Set(ref _targetClusterId, value);

                if (MainData.GetGalaxyMap() != null)
                {
                    MainData.GetGalaxyMap().CanvasConnections.Add(new CanvasConnection(_targetClusterId, MainData.SelectedMapCluster.Id, ConnectionType));
                    MainData.GetGalaxyMap().CanvasConnections.Last().GenerateLine();
                }

            }
        }

        private ConnectionType _connectionType;
        public ConnectionType ConnectionType
        {
            get { return _connectionType; }
            set {

                if (MainData.GetGalaxyMap() != null)
                {
                    var oldConnection = MainData.GetGalaxyMap().CanvasConnections.FirstOrDefault(c => c.ConnectionId1 == _targetClusterId && c.ConnectionId2 == MainData.SelectedMapCluster.Id);

                    if (oldConnection != null)
                        MainData.RemoveConnectionFromCanvas(oldConnection);
                }

                Set(ref _connectionType, value);

                if (MainData.GetGalaxyMap() != null)
                {
                    MainData.GetGalaxyMap().CanvasConnections.Add(new CanvasConnection(_targetClusterId, MainData.SelectedMapCluster.Id, ConnectionType));
                    MainData.GetGalaxyMap().CanvasConnections.Last().GenerateLine();
                }
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
