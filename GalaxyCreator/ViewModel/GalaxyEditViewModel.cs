using GalaSoft.MvvmLight;
using GalaxyCreator.Model.Json;
using GalaxyCreator.ViewModel.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyCreator.ViewModel
{
    public class GalaxyEditViewModel: ViewModelBase, INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly GalaxyValidator _galaxyValidator;
        public Galaxy Galaxy { get; set; } 

        public long Seed { get { return Galaxy.Seed; } set { Galaxy.Seed = value; RaisePropertyChanged("Seed"); } }
        public String GalaxyName { get { return Galaxy.GalaxyName; } set { Galaxy.GalaxyName = value; RaisePropertyChanged("GalaxyName"); } }
        public String GalaxyPrefix { get { return Galaxy.GalaxyPrefix; } set { Galaxy.GalaxyPrefix = value; RaisePropertyChanged("GalaxyPrefix"); } }
        public GalaxyOptions GalaxyOptions { get { return Galaxy.GalaxyOptions; } set { Galaxy.GalaxyOptions = value; RaisePropertyChanged("GalaxyOptions"); } }
        public String Description { get { return Galaxy.Description; } set { Galaxy.Description = value; RaisePropertyChanged("Description"); } }
        public String Author { get { return Galaxy.Author; } set { Galaxy.Author = value; RaisePropertyChanged("Author"); } }
        public String Version { get { return Galaxy.Version; } set { Galaxy.Version = value; RaisePropertyChanged("Version"); } }
        public String Date { get { return Galaxy.Date; } set { Galaxy.Date = value; RaisePropertyChanged("Date"); } }
        public String Save { get { return Galaxy.Save; } set { Galaxy.Save = value; RaisePropertyChanged("Save"); } }
        public int MinRandomBelts { get { return Galaxy.MinRandomBelts; } set { Galaxy.MinRandomBelts = value; RaisePropertyChanged("MinRandomBelts"); } }
        public int MaxRandomBelts { get { return Galaxy.MaxRandomBelts; } set { Galaxy.MaxRandomBelts = value; RaisePropertyChanged("MaxRandomBelts"); } }

        public GalaxyEditViewModel(Galaxy galaxy)
        {
            Galaxy = galaxy;
            _galaxyValidator = new GalaxyValidator();
        }

        public string this[string columnName]
        {
            get
            {
                if (Galaxy != null)
                {
                    var firstOrDefault = _galaxyValidator.Validate(this).Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
                    if (firstOrDefault != null)
                        return _galaxyValidator != null ? firstOrDefault.ErrorMessage : "";
                }
                return "";
            }
        }

        public string Error
        {
            get
            {
                if (_galaxyValidator != null)
                {
                    var results = _galaxyValidator.Validate(this);
                    if (results != null && results.Errors.Any())
                    {
                        var errors = string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray());
                        return errors;
                    }
                }
                return string.Empty;
            }
        }

        private bool HasErrors()
        {
            return Error != string.Empty;
        }
    }
}
