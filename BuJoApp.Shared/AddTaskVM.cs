using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace BuJoApp.Shared
{
    public class AddTaskVM : INotifyPropertyChanged
    {
        public ObservableCollection<AddTaskVM> tasks = new ObservableCollection<AddTaskVM>();

        public ObservableCollection<AddTaskVM> TaskItem
        {
            get { return tasks; }
            set
            {
                if(tasks != value)
                {
                    tasks = value;
                    NotifyPropertyChanged(nameof(tasks));
                }
            }
        }

        public String Name { get; set; }
        public String Desc { get; set; }
        public String Priority { get; set; }
        public String IsDone { get; set; }

        public ICommand AddTaskCommand { get { return new AddTaskCommand(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
