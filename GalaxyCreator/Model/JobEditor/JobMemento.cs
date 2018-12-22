using GalaxyCreator.Model.Json;
using GalaxyCreator.Util;

namespace GalaxyCreator.Model.JobEditor
{

    class JobMemento
    {
        public Job Job { get; set; }

        public JobMemento(Job job)
        {
            this.Job = CloneUtil.DeepClone<Job>(job);
        }
    }
}
