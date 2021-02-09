using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppCoordonates.ViewModels.Commands
{
    public class CoordonatesCommands : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<List<string>> _execute;
        public CoordonatesCommands(Action<List<string>> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter as List<string>);
        }
    }
}
