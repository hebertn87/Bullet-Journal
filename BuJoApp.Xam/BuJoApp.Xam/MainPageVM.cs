using System;
using System.Collections.Generic;
using System.Text;
using BuJoApp.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using BuJoApp.DB;
using BuJoApp.Shared;

namespace BuJoApp.Xam
{
    public class MainPageVM : INotifyPropertyChanged
    {
        private readonly IDataStore dataStore;

        public MainPageVM(IDataStore dataStore)
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
            Tasks = new ObservableCollection<Task>(DataStore.GetAllTasks());
        }

        public IDataStore DataStore => dataStore;

        private String title;
        public String Title
        {
            get { return title; }
            set { SetField(ref title, value); }
        }

        private String content;
        public String Content
        {
            get { return content; }
            set { SetField(ref content, value); }
        }

        private String pageNum;
        public String PageNum
        {
            get { return pageNum; }
            set { SetField(ref pageNum, value); }
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

        private Command addPageCommand;
        public Command AddPageCommand => addPageCommand ?? (addPageCommand = new Command(
            () =>
            {
                DataStore.AddTask(new Task(
                    Title,
                    Content,
                    PageNum));
                Tasks.Clear();
                foreach (var c in DataStore.GetAllTasks())
                    Tasks.Add(c);

                Title = null;
            }));

        public ObservableCollection<Task> Tasks { get; private set; }
    }
}

