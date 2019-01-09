using GalaSoft.MvvmLight;
using System;
using System.IO;
using System.Reflection;

namespace GalaxyCreator.ViewModel
{
    class HelpViewModel : ViewModelBase
    {
        public String Content { get; set; }

        public HelpViewModel()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Help\help.html");
            Content = File.ReadAllText(path);
        }
    }
}
