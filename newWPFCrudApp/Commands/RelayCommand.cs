using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace newWPFCrudApp.Commands
{
    class RelayCommand : ICommand
    {
        Action<object> execute;
        Func<object, bool> canExecute;
        bool canExecuteCache;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute, bool canExecuteCache)

        {
            this.execute = execute;
            this.canExecute = canExecute;
            this.canExecuteCache = canExecuteCache;
        }

        public event EventHandler? CanExecuteChanged
        {
            add
            {

                CommandManager.RequerySuggested += value;

            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }

        }


        public bool CanExecute(object? parameter)
        {
            if (canExecute == null)
            {
                return true;
            }
            else
            {
                return canExecute(parameter);
            }
        }

        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }
}
