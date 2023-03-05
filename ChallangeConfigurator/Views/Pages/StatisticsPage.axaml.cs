using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ChallangeConfigurator.ViewModels.Pages;
using ReactiveUI;

namespace ChallangeConfigurator.Views.Pages;

public partial class StatisticsPage : ReactiveUserControl<StatisticsPageViewModel>
{
    public StatisticsPage()
    {
        this.WhenActivated(disposables => { });

        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}