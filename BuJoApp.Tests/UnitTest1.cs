using NUnit.Framework;
using BuJoApp.Shared;

namespace Tests
{
    public class Tests
    {

        TaskVM taskList = new TaskVM();
        Task tasks = new Task();
        string nameTest = "ahlo";
        string descTest = "This";
        string priorityTest = "1000";
        bool isDoneTest = true;

        [Test]
        public void TestName()
        {
            taskList.TaskItem.Clear();
            taskList.Name = "ahlo";

            taskList.TaskItem.Add(new TaskVM() { Name = taskList.Name, Desc = taskList.Desc, Priority = taskList.Priority, IsDone = taskList.IsDone});
            Assert.AreEqual(taskList.TaskItem[0].Name, nameTest);           
        }

        [Test]
        public void TestDesc()
        {
            taskList.TaskItem.Clear();
            taskList.Desc = "This";

            taskList.TaskItem.Add(new TaskVM() { Name = taskList.Name, Desc = taskList.Desc, Priority = taskList.Priority, IsDone = taskList.IsDone });
            Assert.AreEqual(taskList.TaskItem[0].Desc, descTest);
        }

        [Test]
        public void TestPriority()
        {
            taskList.TaskItem.Clear();
            taskList.Priority = "1000";

            taskList.TaskItem.Add(new TaskVM() { Name = taskList.Name, Desc = taskList.Desc, Priority = taskList.Priority, IsDone = taskList.IsDone });
            Assert.AreEqual(taskList.TaskItem[0].Priority, priorityTest);
        }

        [Test]
        public void TestIsDone()
        {
            taskList.TaskItem.Clear();
            taskList.IsDone = true;

            taskList.TaskItem.Add(new TaskVM() { Name = taskList.Name, Desc = taskList.Desc, Priority = taskList.Priority, IsDone = taskList.IsDone });
            Assert.AreEqual(taskList.TaskItem[0].IsDone, isDoneTest);
        }

        [Test]
        public void RemoveAll()
        {
            taskList.Name = "ahlo";
            taskList.Desc = "This"; ;
            taskList.Priority = "1000";
            taskList.IsDone = true;
            taskList.TaskItem.Add(new TaskVM() { Name = taskList.Name, Desc = taskList.Desc, Priority = taskList.Priority, IsDone = taskList.IsDone });
            taskList.TaskItem.Clear();

            Assert.AreEqual(0, taskList.TaskItem.Count);
        }

        [Test]
        public void RemoveName()
        {
            taskList.Name = "ahlo";

            taskList.TaskItem.Add(new TaskVM() { Name = taskList.Name, Desc = taskList.Desc, Priority = taskList.Priority, IsDone = taskList.IsDone });
            taskList.TaskItem.RemoveAt(0);
            Assert.AreEqual(0, taskList.TaskItem.Count);
        }

        [Test]
        public void RemoveDesc()
        {
            taskList.Desc = "This"; 

            taskList.TaskItem.Add(new TaskVM() { Name = taskList.Name, Desc = taskList.Desc, Priority = taskList.Priority, IsDone = taskList.IsDone });
            taskList.TaskItem.RemoveAt(0);
            Assert.AreEqual(0, taskList.TaskItem.Count);
        }

        [Test]
        public void RemovePriority()
        {
            taskList.Priority = "1000";

            taskList.TaskItem.Add(new TaskVM() { Name = taskList.Name, Desc = taskList.Desc, Priority = taskList.Priority, IsDone = taskList.IsDone });
            taskList.TaskItem.RemoveAt(0);
            Assert.AreEqual(0, taskList.TaskItem.Count);
        }

        [Test]
        public void RemoveIsDone()
        {
            taskList.IsDone = true;

            taskList.TaskItem.Add(new TaskVM() { Name = taskList.Name, Desc = taskList.Desc, Priority = taskList.Priority, IsDone = taskList.IsDone });
            taskList.TaskItem.RemoveAt(0);
            Assert.AreEqual(0, taskList.TaskItem.Count);
        }
    }
}