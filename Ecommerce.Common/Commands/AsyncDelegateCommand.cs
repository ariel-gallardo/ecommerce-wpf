using System.Windows.Input;

namespace Ecommerce.Common
{
    public class AsyncDelegateCommand : ICommand
    {
        private readonly Func<object?, Task> _task;
        private readonly Func<object, bool?> _canExecute;

        public AsyncDelegateCommand(Func<object?, Task> task, Func<object,bool?> canExecute = null)
        {
            _task = task ?? throw new ArgumentNullException(nameof(task));
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object? parameter) => Task.Run(() => parameter != null ? _task(parameter) : _task(null));

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
