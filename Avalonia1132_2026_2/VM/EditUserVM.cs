using System;
using System.Windows.Input;

namespace Avalonia1132_2026_2.VM;

public class EditUserVM : BaseVM
{
    private Action<UserVM> close;
    public UserVM User { get; set; }
    
    public ICommand SaveCommand { get; private set; }
    
    public EditUserVM()
    {
        SaveCommand = new RelayCommand<string>(s =>
        {
            close(User);
        });
    }
    public void Init(UserVM user, Action<UserVM> close)
    {
        User = user;
        this.close = close;
    }
}