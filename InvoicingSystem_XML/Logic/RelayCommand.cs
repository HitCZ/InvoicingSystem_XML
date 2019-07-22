using System;
using System.Windows.Input;

namespace InvoicingSystem_XML.Logic
{
    public class RelayCommand : ICommand
    {
        private readonly Action executeAction;
        private readonly Func<bool> canExecuteFunc;

        public RelayCommand(Action executeAction) : this(executeAction, null)
        {
        }

        public RelayCommand(Action executeAction, Func<bool> canExecuteFunc)
        {
            this.executeAction = executeAction ?? throw new ArgumentNullException($"{nameof(executeAction)} is null.");
            this.canExecuteFunc = canExecuteFunc;
        }

        #region ICommand

        public bool CanExecute(object parameter) => canExecuteFunc is null || canExecuteFunc.Invoke();

        public void Execute(object parameter) => executeAction.Invoke();

        public event EventHandler CanExecuteChanged;
        
        #endregion ICommand
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> executeAction;
        private readonly Func<T, bool> canExecuteFunc;

        public RelayCommand(Action<T> executeAction) : this(executeAction, null)
        {
        }

        public RelayCommand(Action<T> executeAction, Func<T, bool> canExecuteFunc)
        {

            this.executeAction = executeAction ?? throw new ArgumentNullException($"{nameof(executeAction)} is null.");
            this.canExecuteFunc = canExecuteFunc;
        }

        #region ICommand

        public bool CanExecute(object parameter)
        {
            if (parameter is null)
                throw new ArgumentNullException($"{nameof(parameter)} is null");

            var isValid = IsTypeValid(parameter, out var convertedValue);

            return isValid && canExecuteFunc(convertedValue);
        }

        public void Execute(object parameter)
        {
            if (parameter is null)
                throw new ArgumentNullException($"{nameof(parameter)} is null");

            var isValid = IsTypeValid(parameter, out var convertedValue);

            if (!isValid)
                return;
            executeAction.Invoke(convertedValue);
        }

        public event EventHandler CanExecuteChanged;
        
        #endregion ICommand

        private bool IsTypeValid(object parameter, out T convertedValue)
        {
            convertedValue = default;
            var parameterType = parameter.GetType();
            var genericType = typeof(T);

            var isValid = genericType == parameterType;

            if (isValid)
                convertedValue = (T)parameter;

            return isValid;
        }
    }
}
