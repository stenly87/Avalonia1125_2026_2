using System;

namespace Avalonia1132_2026_2.VM;

public class UserVM : BaseVM
{
    private readonly User _user;

    public string Name
    {
        get => _user.Name;
        set
        {
            _user.Name = value;
            OnPropertyChanged();
        }
    }

    public DateTimeOffset Birthday
    {
        get => _user.Birthday;
        set
        {
            _user.Birthday = new DateTime(value.Year, value.Month, value.Day);
            OnPropertyChanged();
        }
    }

    public double LazyLevel
    {
        get => _user.LazyLevel;
        set
        {
            _user.LazyLevel = value;
            OnPropertyChanged();
        }
    }

    public UserVM(User user)
    {
        _user = user;
    }
}