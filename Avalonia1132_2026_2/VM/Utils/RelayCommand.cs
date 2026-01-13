using System;
using System.Windows.Input;

namespace Avalonia1132_2026_2.VM;

public class RelayCommand<T> : ICommand
{
    private Action<T> action;

    public RelayCommand(Action<T> action)
    {
        this.action = action;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        action((T)parameter);
    }

    public event EventHandler? CanExecuteChanged;
}