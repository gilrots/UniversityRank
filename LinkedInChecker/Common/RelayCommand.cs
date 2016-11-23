using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace LinkedInChecker
{
    /// <summary>
    /// Infrastuctre for Mvvm Commands
    /// </summary>
    public class RelayCommand : ICommand
    {
        public Action<object> ActionToDo;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> Action)
        {
            ActionToDo = Action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ActionToDo(parameter);
        }
    }
}
