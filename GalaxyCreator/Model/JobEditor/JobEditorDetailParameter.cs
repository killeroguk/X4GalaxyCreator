using GalaxyCreator.Model.Json;
using System.Windows;

namespace GalaxyCreator.Model.JobEditor
{
    /**
     * I'm not using this class anymore but it's a good teacher how to use DependencyObject for binding several parameters in a CommandParameter
     **/
    public class JobEditorDetailParameter : DependencyObject
    {
        public static readonly DependencyProperty ParentWindowProperty = DependencyProperty.Register(nameof(ParentWindow), typeof(Window), typeof(JobEditorDetailParameter));
        public static readonly DependencyProperty JobProperty = DependencyProperty.Register(nameof(Job), typeof(Job), typeof(JobEditorDetailParameter));

        public Window ParentWindow
        {
            get { return (Window)GetValue(ParentWindowProperty); }
            set { SetValue(ParentWindowProperty, value); }
        }

        public Job Job
        {
            get { return (Job)GetValue(JobProperty); }
            set { SetValue(JobProperty, value); }
        }
    }
}
