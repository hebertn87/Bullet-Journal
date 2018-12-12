using System.Collections.ObjectModel;

namespace BuJoApp.Interfaces
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
            Name = "";
            Desc = "";
            Priority = "";
            IsDone = false;
        }

        public string Name { get; set; }
        public string Desc { get; set; }
        public string Priority { get; set; }
        public bool IsDone { get; set; }
    }
}
