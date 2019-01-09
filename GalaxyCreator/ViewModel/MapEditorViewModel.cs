using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaxyCreator.Model;
using GalaxyCreator.Model.Json;
using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GalaxyCreator.ViewModel
{
    public class MapEditorViewModel : ViewModelBase
    {
        private CanvasElementType oldSelectedCanvasElementType;
        private Shape oldSelectedCanvasElement;

        private RelayCommand<MouseButtonEventArgs> _canvasClickedCommand;

        private Object _rightHandViewModel;
        private Galaxy galaxy;



        public MapEditorViewModel(Galaxy galaxy)
        {
            this.galaxy = galaxy;


            //if ( MainData.Canvas != null)
            //    DrawGalaxyMap();
            
        }


        public void DrawGalaxyMap()
        {
            if(MainData.GetGalaxyMap() != null)
            {
                foreach (Cluster mapCluster in MainData.GetGalaxyMap().Clusters)
                {
                    MainData.AddChildToCanvas(CanvasElementType.CLUSTER, mapCluster.Polygon, mapCluster.UId.ToString());
                }

                MainData.Canvas.UpdateLayout();

                foreach (CanvasConnection con in MainData.GetGalaxyMap().CanvasConnections)
                {
                    con.GenerateLine();
                }
            }
        }


        public Object RightHandViewModel
        {
            get { return _rightHandViewModel; }
            set
            {
                Set(ref _rightHandViewModel, value);
            }
        }

        public RelayCommand<MouseButtonEventArgs> CanvasClickedCommand
        {
            get
            {
                if (_canvasClickedCommand == null)
                {
                    _canvasClickedCommand = new RelayCommand<MouseButtonEventArgs>((e) => CanvasClicked(e));
                }

                return _canvasClickedCommand;
            }
        }

        public void CanvasClicked(MouseButtonEventArgs e)
        {

            /* TODO: SOME HOW CHECK WHAT WAS CLICKED ON */

            /* CHECK TO SEE IF A SHAPE HAS BEEN CLICKED ON OR THE CANVAS ITS SELF */
            if (e.Source.GetType() != typeof(Canvas))
            {
                CanvasElementType selectedCanvasType = MainData.GetShapeType((Shape)e.Source);

                if (oldSelectedCanvasElement != null)
                {

                    switch (oldSelectedCanvasElementType)
                    {
                        case CanvasElementType.CLUSTER:
                            {
                                oldSelectedCanvasElement.Stroke = Brushes.Black;
                                Canvas.SetZIndex(oldSelectedCanvasElement, 0);
                                break;
                            }
                    }
                }

                switch (selectedCanvasType)
                {
                    case CanvasElementType.CLUSTER:
                        {


                            Galaxy galaxy = MainData.GetGalaxyMap();


                            Cluster selectedCluster = ((List<Cluster>)galaxy.Clusters).Find(s => s.UId == (Guid)((Polygon)e.Source).Tag);

                            oldSelectedCanvasElement = selectedCluster.Polygon;
                            oldSelectedCanvasElementType = CanvasElementType.CLUSTER;

                            /* SHOW A HIGHLIGHT AROUND THE SELECTED CLUSTER */
                            selectedCluster.Polygon.Stroke = Brushes.Yellow;
                            Canvas.SetZIndex(selectedCluster.Polygon, 1);

                            

                            //MainData.UpdateCanvas();

                            RightHandViewModel = new SectorEditViewModel(selectedCluster);
                            break;
                        }
                }
            }
            else
            {
                RightHandViewModel = new GalaxyEditViewModel(galaxy);
            }



        }

        public override void Cleanup()
        {
            /* CLEARS ALL THE CHILD ELEMENTS FROM THE CANVAS */
            MainData.Canvas.Children.Clear();
            base.Cleanup();
        }

    }
}
