using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BuJoApp.Shared
{
    public class DelTaskCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(Object param)
        {
            if (param is TaskVM taskList)
                taskList.TaskItem.Remove(new TaskVM() { Name = taskList.Name, Desc = taskList.Desc, Priority = taskList.Priority, IsDone = taskList.IsDone });
        }
    }
    
}
