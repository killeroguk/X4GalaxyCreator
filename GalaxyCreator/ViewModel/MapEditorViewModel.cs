using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaxyCreator.Model;
using GalaxyCreator.Model.Json;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace GalaxyCreator.ViewModel
{
    public class MapEditorViewModel : ViewModelBase
    {
        private int _rowCount;
        private int _columnCount;

        private RelayCommand<MouseButtonEventArgs> _canvasClickedCommand;

        private Object _rightHandViewModel;
        private Galaxy galaxy;

        public MapEditorViewModel(Galaxy galaxy)
        {
            this.galaxy = galaxy;
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

                switch (selectedCanvasType)
                {
                    case CanvasElementType.sector:
                        {
                            SectorGrid grid = MainData.GetSectorGrid();
                            Sector selectedSector = grid.Sectors.Find(s => s.Id == (Guid)((Polygon)e.Source).Tag);

                            RightHandViewModel = new SectorEditViewModel(selectedSector);
                            break;
                        }
                }
            }
            else
            {
                RightHandViewModel = new GalaxyEditViewModel();
            }



        }
    }
}
