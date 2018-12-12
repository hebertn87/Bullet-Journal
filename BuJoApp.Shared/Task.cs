using System.Collections.ObjectModel;

namespace BuJoApp.Shared
{
    public class Task
    {
        public Task(string name, string description, string priority, bool isDone)
        {
            Name = name;
            Desc= description;
            Priority = priority;
            IsDone = isDone;
        }

        public Task()
        {
            Name = null;
            Desc = null;
            Priority = null;
            IsDone = false;
        }

        public string Name { get; set; }
        public string Desc { get; set; }
        public string Priority { get; set; }
        public bool IsDone { get; set; }
    }
}
