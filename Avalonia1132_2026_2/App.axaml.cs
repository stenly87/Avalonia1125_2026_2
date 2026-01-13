using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia1132_2026_2.DB;
using Avalonia1132_2026_2.View;
using Avalonia1132_2026_2.VM;
using Microsoft.Extensions.DependencyInjection;

namespace Avalonia1132_2026_2;

public partial class App : Application
{
    internal static ServiceProvider Services { get; private set; }
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var services = new ServiceCollection();
            services.AddTransient<MainVM>();
            services.AddTransient<MainWindow>();
            services.AddTransient<EditUserVM>();
            services.AddTransient<EditUserWindow>();
            services.AddDbContext<_12pupupuContext>();
            
            Services = services.BuildServiceProvider();

            var win = Services.GetRequiredService<MainWindow>();
            var vm = Services.GetRequiredService<MainVM>();
            win.DataContext = vm;
            desktop.MainWindow = win;
        }

        base.OnFrameworkInitializationCompleted();
    }
}