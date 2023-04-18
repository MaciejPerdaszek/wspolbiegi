using System;
using System.Windows.Input;

namespace Prezentacja.ViewModel
{
    public class Commands : ICommand
    {
       private readonly Action<object> onExecute;
       private readonly Predicate<object> canExecute;

        public Commands(Action<Object> execute) :
            this(execute, null)
        {
        }

        public Commands(Action<Object> execute, Predicate<Object> canexecute) 
        {
           onExecute = execute ?? throw new ArgumentNullException("execute");
           canExecute = canexecute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object? parameter) 
        {
            onExecute(parameter);
        }
    }
}
