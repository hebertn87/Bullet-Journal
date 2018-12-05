using System;
using BuJoApp.Interfaces;
using System.Windows.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace BuJoApp.Shared
{
    public class AddTaskVM : INotifyPropertyChanged, IPageVM
    {
        public string Nameof
        {
            get { return "AddPage"; }
        }

        private readonly TaskContext repo;

        public AddTaskVM(TaskContext repo)
        {
            this.repo = repo ?? throw new ArgumentNullException(nameof(repo));
            
        }

        private String name;
        public String Name
        {
            get { return name; }
            set { SetField(ref name, value); }
        }

        private String description;
        public String Description
        {
            get { return description; }
            set { SetField(ref description, value); }
        }

        private String priority;
        public String Priority
        {
            get { return priority; }
            set { SetField(ref priority, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private ICommand addTask;
        public ICommand AddTask => addTask ?? (addTask = new BuJoCommand(param =>
        {
            repo.AddTask(new Task(Name, Description, Priority));
        }));

        public ObservableCollection<Task> Tasks { get; private set; }

    }
}
