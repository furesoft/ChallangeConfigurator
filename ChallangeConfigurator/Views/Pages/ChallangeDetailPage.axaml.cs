using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ChallangeConfigurator.ViewModels.Pages;
using ReactiveUI;

namespace ChallangeConfigurator.Views.Pages;

public partial class ChallangeDetailPage : ReactiveUserControl<ChallangeDetailPageViewModel>
{
    public ChallangeDetailPage()
    {
        this.WhenActivated(disposables => { });
        
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}