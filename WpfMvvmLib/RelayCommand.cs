using System;
using System.Windows.Input;

namespace WpfMvvmLib
{
    public class RelayCommand : ICommand
    {
        private readonly Func<object, bool> _canExec;
        private readonly Action<object> _exec;

        public RelayCommand(Func<object, bool> canExec, Action<object> exec)
        {
            _canExec = canExec;
            _exec = exec;
        }

        public void Execute(object parameter)
        {
            if (_exec != null)
            {
                _exec(parameter);
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExec != null && _canExec(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}