using System.Collections.ObjectModel;
using ChallangeConfigurator.Models.UI;
using ReactiveUI;

namespace ChallangeConfigurator.Core;

public abstract class PageViewModel : ReactiveObject, IRoutableViewModel
{
    public ObservableCollection<ActionButton> HeaderButtons { get; set; } = new();
    
    public string? UrlPathSegment { get; }
    
    public IScreen HostScreen { get; }
}