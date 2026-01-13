using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia1132_2026_2.View;
using Microsoft.Extensions.DependencyInjection;

namespace Avalonia1132_2026_2.VM;

public class MainVM : BaseVM
{
    public UserVM SelectedUser
    {
        get => _selectedUser;
        set
        {
            if (Equals(value, _selectedUser)) return;
            _selectedUser = value;
            OnPropertyChanged();
            EditUserCommand.RaiseCanExecuteChanged();
        }
    }

    private ObservableCollection<UserVM> _users = new();
    private UserVM _selectedUser;

    public ObservableCollection<UserVM> Users
    {
        get => _users;
        set
        {
            if (Equals(value, _users)) return;
            _users = value;
            OnPropertyChanged();
        }
    }
    
    public ICommand AddUserCommand { get; private set; }
    public RelayCommandWithCheckAccess<Window> EditUserCommand { get;private set; }
    public MainVM()
    {
        AddUserCommand = new RelayCommand<Window>(async s =>
        {
            var win = App.Services.GetRequiredService<EditUserWindow>();
            var vm = App.Services.GetRequiredService<EditUserVM>();
            vm.Init(new UserVM(new User()), win.CloseFromVM);
            win.DataContext = vm;
            var result = await win.ShowDialog<UserVM>(s);
            Users.Add(result);
        });

        EditUserCommand = new RelayCommandWithCheckAccess<Window>(async s =>
        {
            if (SelectedUser != null)
            {
                var win = App.Services.GetRequiredService<EditUserWindow>();
                var vm = App.Services.GetRequiredService<EditUserVM>();
                vm.Init(SelectedUser, win.CloseFromVM);
                win.DataContext = vm;
                var result = await win.ShowDialog<UserVM>(s);
            }
        },
            ()=>SelectedUser != null);
    }
}