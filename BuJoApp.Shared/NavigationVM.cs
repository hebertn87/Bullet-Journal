using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BuJoApp.Shared
{
    public class NavigationVM : INotifyPropertyChanged
    {
        private object selectedVM;
        public object SelectedVM
        {
            get
            {
                return selectedVM;
            }
            set
            {
                selectedVM = value;
                OnPropertyChanged("SelectedViewModel");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyChanged)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
        }
    }
}
