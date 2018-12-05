using BuJoApp.Interfaces;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace BuJoApp.Shared
{
    public class MainWindowVM
    {
        public ICommand MonthlyCommand { get; set; }
        public ICommand TaskCommand { get; set; }
        
        public IDataStore dataStore;
        public TaskContext repo;

        private readonly NavigationVM navVM;
        public MainWindowVM(NavigationVM _navVM)
        {
            navVM = _navVM;

            MonthlyCommand = new BuJoCommand(OpenMonthly);
            //WeeklyCommand = ...
            //Dailycommand?
            TaskCommand = new BuJoCommand(OpenAddTask);
        }

        public void OpenMonthly(object obj)
        {
            navVM.SelectedVM = new MonthlyVM();
        }

        private void OpenAddTask(object obj)
        {
            navVM.SelectedVM = new AddTaskVM(repo);
        }
    }
}
