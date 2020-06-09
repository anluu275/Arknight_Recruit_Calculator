using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Arknight_Recruit_Calculator
{
    public class DoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action _methodToExecute;
        private Func<bool> _canExecute;

        //If only methodToExecute parameter given, then use second constructor with Func<bool> as true
        public DoCommand(Action methodToExecute) :
            this(methodToExecute, () => true)
        { }

        public DoCommand(Action methodToExecute, Func<bool> canExecuteMethod)
        {
            _methodToExecute = methodToExecute;
            _canExecute = canExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                return _canExecute();
            }

            return false;
        }

        public void Execute(object parameter)
        {
            if (_methodToExecute != null)
            {
                _methodToExecute.Invoke();
            }
        }
    }

    public class DoCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<T> _methodToExecute;
        private Func<T, bool> _canExecute;

        //If only methodToExecute parameter given, then use second constructor with Func<bool> as true
        public DoCommand(Action<T> methodToExecute) :
            this(methodToExecute, (T) => true)
        { }

        public DoCommand(Action<T> methodToExecute, Func<T, bool> canExecuteMethod)
        {
            _methodToExecute = methodToExecute;
            _canExecute = canExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                T tparam = (T)parameter;
                return _canExecute(tparam);
            }
            return false;
        }

        public void Execute(object parameter)
        {
            if (_methodToExecute != null)
            {
                _methodToExecute.Invoke((T)parameter);
            }
        }
    }
}
