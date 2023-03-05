using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ChallangeConfigurator.ViewModels;
using ChallangeConfigurator.Views;
using LiteDB;
using ReactiveUI;
using Splat;

namespace ChallangeConfigurator;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        Locator.CurrentMutable.RegisterConstant<ILiteRepository>(new LiteRepository("Filename=./data.db; Connection=shared;"));
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        AppDomain.CurrentDomain.ProcessExit += (s, e) =>
        {
            Locator.Current.GetService<ILiteRepository>().Dispose();
        };
        
        Locator.CurrentMutable.RegisterViewsForViewModels(GetType().Assembly);
        
        base.OnFrameworkInitializationCompleted();
    }
}