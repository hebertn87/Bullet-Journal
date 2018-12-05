using System;
using System.Collections.Generic;
using System.Text;

namespace BuJoApp.Interfaces
{
    public class TaskContext
    {
        private readonly IDataStore dataStore;

        public TaskContext(IDataStore dataStore)
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }

        public bool AddTask(Task t)
        {
            try
            {
                dataStore.AddTask(t);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return dataStore.GetAllTasks();
        }
    }
}
