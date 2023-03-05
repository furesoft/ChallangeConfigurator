using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ChallangeConfigurator.ViewModels.Pages;
using ReactiveUI;

namespace ChallangeConfigurator.Views.Pages;

public partial class ChallangesPage : ReactiveUserControl<ChallangesPageViewModel>
{
    public ChallangesPage()
    {
        this.WhenActivated(disposables => { });

        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}