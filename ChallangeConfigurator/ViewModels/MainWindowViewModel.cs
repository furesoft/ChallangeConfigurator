using System.Collections.Immutable;
using System.Reactive;
using ChallangeConfigurator.ViewModels.Pages;
using DynamicData;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace ChallangeConfigurator.ViewModels;

public class MainWindowViewModel : ReactiveObject, IScreen
{
    public RoutingState Router { get; } = new RoutingState();
    
    public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }
    
    public ReactiveCommand<Unit, IRoutableViewModel> GoBack => Router.NavigateBack;

    [Reactive]
    public string PageTitle { get; set; }
    
    [Reactive]
    public bool CanGoBack { get; set; }
    
    public MainWindowViewModel()
    {
        Locator.CurrentMutable.RegisterConstant(Router);
        
        Router.Navigate.Execute(new MainMenuPageViewModel());

        Router.NavigationChanged.Subscribe(Observer.Create<IChangeSet<IRoutableViewModel>>(_ =>
        {
            PageTitle = Router.GetCurrentViewModel().UrlPathSegment;
            CanGoBack = Router.NavigationStack.Count != 1;
        }));
    }
}