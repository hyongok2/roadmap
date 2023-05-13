using System;
using System.Windows.Input;

namespace ModernVPN.Core
{
    public class RelayCommand : ICommand
    {
        private Action<object?> _execute;
        private Func<Object?, bool>? _canExecute;
        
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value;}
        }
        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(arg: parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(obj: parameter);
        }
    }
}
