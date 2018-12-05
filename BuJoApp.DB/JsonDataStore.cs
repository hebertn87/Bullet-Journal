using BuJoApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace BuJoApp.DB
{
    public class JsonDataStore : IDataStore
    {
        private const string Path = "bulletjournal.json";

        public JsonDataStore()
        {
            if (File.Exists(Path))
            {
                tasks = JsonConvert.DeserializeObject<List<Task>>(File.ReadAllText(Path));
            }
            else
            {
                tasks = new List<Task>();
            }
        }

        private List<Task> tasks;

        public void AddPage(Task p)
        {
            tasks.Add(p);
            syncToDisk();
        }

        private void syncToDisk()
        {
            File.WriteAllText(Path, JsonConvert.SerializeObject(tasks));
        }

        public IEnumerable<Task> GetAllPages()
        {
            return tasks;
        }

        public void AddTask(Task t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task> GetAllTasks()
        {
            throw new NotImplementedException();
        }
    }
}
