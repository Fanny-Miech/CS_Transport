using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfDisplayTransportMessage.ViewModel.Commands
{
    public class CoordonatesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _execute;
        public CoordonatesCommand(Action execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this._execute();
        }

    }
}
