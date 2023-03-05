using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ChallangeConfigurator.ViewModels;
using ReactiveUI;

namespace ChallangeConfigurator.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        this.WhenActivated(disposables => { });
        
        InitializeComponent();
    }
}