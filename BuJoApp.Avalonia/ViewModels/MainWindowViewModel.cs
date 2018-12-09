using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BuJoApp.DB;
using BuJoApp.Interfaces;
using BuJoApp.Shared;

namespace BuJoApp.Avalonia.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IDataStore dataStore;

        public MainWindowViewModel()
        {

        }

        public MainWindowViewModel(IDataStore dataStore)
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
            Pages = new ObservableCollection<Task>(DataStore.GetAllTasks());
        }

        public IDataStore DataStore => dataStore;

        private String name;
        public String Name
        {
            get { return name; }
            set { SetField(ref name, value); }
        }

        private String desc;
        public String Description
        {
            get { return desc; }
            set { SetField(ref desc, value); }
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

        private ICommand addPage;
        public ICommand AddPage => addPage ?? (addPage = new BuJoCommand(param =>
        {
            DataStore.AddTask(new Task(
                Name,
                Description,
                Priority));
            Pages.Clear();
            foreach (var c in DataStore.GetAllTasks())
                Pages.Add(c);

             Name = null;
        }));

        public ObservableCollection<Task> Pages { get; private set; }
    }
}
