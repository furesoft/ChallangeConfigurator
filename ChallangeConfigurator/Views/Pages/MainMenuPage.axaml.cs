using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ChallangeConfigurator.ViewModels.Pages;
using ReactiveUI;

namespace ChallangeConfigurator.Views.Pages;

public partial class MainMenuPage : ReactiveUserControl<MainMenuPageViewModel>
{
    public MainMenuPage()
    {
        this.WhenActivated(disposables => { });
        
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}