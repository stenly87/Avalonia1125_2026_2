using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia1132_2026_2.VM;

namespace Avalonia1132_2026_2.View;

public partial class EditUserWindow : Window
{
    public EditUserWindow()
    {
        InitializeComponent();
    }
    
    public void CloseFromVM(UserVM result)
    {
        Close(result);
    }
}