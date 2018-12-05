using System.Collections.ObjectModel;

namespace BuJoApp.Interfaces
{
    public class Task
    {
        public Task(string name, string description, string priority)
        {
            Name = name;
            Description = description;
            Priority = priority;
        }

        public int TaskID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }

        public virtual ObservableCollection<Task> Tasks { get; private set; }
    }
}
