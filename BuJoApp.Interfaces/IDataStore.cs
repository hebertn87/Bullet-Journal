using System;
using System.Collections.Generic;
using System.Text;

namespace BuJoApp.Interfaces
{
    public interface IDataStore
    {
        void AddTask(Task t);
        IEnumerable<Task> GetAllTasks();
    }
}
