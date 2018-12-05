using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BuJoApp.Interfaces
{
    public class BuJoCommand : ObservableObject, ICommand
    {
        private readonly Func<bool> canExecute;
        private readonly Action<object> execute;
        private IDataStore dataStore;

        public BuJoCommand(Action<object> execute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public BuJoCommand(Func<bool> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public BuJoCommand(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
                return canExecute();
            return true;
        }

        internal void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
