using System.Windows.Input;

namespace Chevalier.Utility.Commands
{
    public class DelegateCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<T> executeAction;
        private readonly Func<T, bool> canExecuteFunction;

        /// <summary>
        /// Creates a command with an action delegate to be invoked when executing the command.
        /// A function delegate may optionally be provided to determine whether the command can be executed.
        /// </summary>
        /// <param name="executeAction">Action to be invoked when executing the command. Must not be null.</param>
        /// <param name="canExecuteFunction">Function that determines whether the command can be executed. May be null if the command can always be executed.</param>
        /// <exception cref="ArgumentNullException">If the execute action is null.</exception>
        public DelegateCommand(Action<T> executeAction, Func<T, bool> canExecuteFunction = null)
        {
            this.executeAction = executeAction ?? throw new ArgumentNullException(nameof(executeAction));
            this.canExecuteFunction = canExecuteFunction;
        }

        /// <summary>
        /// Determines whether the command can be executed.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data, this may be null.</param>
        /// <returns>True if the command can be executed. Otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return CanExecute((T)parameter);
        }

        /// <summary>
        /// Determines whether the command can be executed.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data, this may be null.</param>
        /// <returns>True if the command can be executed. Otherwise, false.</returns>
        public bool CanExecute(T parameter)
        {
            return canExecuteFunction?.Invoke(parameter) ?? true;
        }

        /// <summary>
        /// Executes the command if it can be executed.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data, this may be null.</param>
        public void Execute(object parameter)
        {
            Execute((T)parameter);
        }

        /// <summary>
        /// Executes the command if it can be executed.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data, this may be null.</param>
        public void Execute(T parameter)
        {
            if (CanExecute(parameter))
                executeAction.Invoke(parameter);
        }

        /// <summary>
        /// Invokes the CanExecuteChanged event to indicate that changes have occurred that affect
        /// whether the command can be executed.
        /// </summary>
        public void NotifyCanExecuteChanged()
        {
            NotifyCanExecuteChanged(sender: this);
        }

        /// <summary>
        /// Invokes the CanExecuteChanged event to indicate that changes have occurred that affect
        /// whether the command can be executed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        public void NotifyCanExecuteChanged(object sender)
        {
            CanExecuteChanged?.Invoke(sender, EventArgs.Empty);
        }
    }

    public class DelegateCommand : DelegateCommand<object>
    {
        /// <summary>
        /// Creates a command with an action delegate to be invoked when executing the command.
        /// A function delegate may optionally be provided to determine whether the command can be executed.
        /// </summary>
        /// <param name="executeAction">Action to be invoked when executing the command. Must not be null.</param>
        /// <param name="canExecuteFunction">Function that determines whether the command can be executed. May be null if the command can always be executed.</param>
        /// <exception cref="ArgumentNullException">If the execute action is null.</exception>
        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteFunction = null)
            : base(executeAction, canExecuteFunction)
        { }
    }
}
