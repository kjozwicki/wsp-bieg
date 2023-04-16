using System;
using System.Windows.Input;

namespace ViewModel
{
    public class RelayCommandBase : ICommand
    {
        
        public event EventHandler? CanExecuteChanged;
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        
        internal void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        
        public bool CanExecute(object? parameter)
        {
            if (_canExecute == null)
                return true;
            if (parameter == null)
                return _canExecute();
            return _canExecute();
        }
        
        
        
        public virtual void Execute(object parameter)
        {
            _execute();
        }
        
        
        public RelayCommandBase(Action execute) : this(execute, null) { }
        public RelayCommandBase(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }


    }
}