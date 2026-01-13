using System;
using System.Windows.Input;

namespace Avalonia1132_2026_2.VM;

public class RelayCommandWithCheckAccess<T> : ICommand
{
    private Action<T> action;
    Func<bool> canExecute;
    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
    public RelayCommandWithCheckAccess(Action<T> action, Func<bool> canExecute)
    {
        this.action = action;
        this.canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        return canExecute();
    }

    public void Execute(object? parameter)
    {
        action((T)parameter);
    }

    public event EventHandler? CanExecuteChanged;
}