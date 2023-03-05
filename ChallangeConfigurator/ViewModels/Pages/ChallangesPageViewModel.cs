using System.Collections.ObjectModel;
using ChallangeConfigurator.Core;
using ChallangeConfigurator.Models;
using ChallangeConfigurator.Models.UI;
using LiteDB;
using Material.Icons;
using ReactiveUI;
using Splat;

namespace ChallangeConfigurator.ViewModels.Pages;

public class ChallangesPageViewModel : PageViewModel
{
    public Game SelectedGame { get; }

    public ObservableCollection<Challange> Challanges { get; set; }
    
    public ChallangesPageViewModel(Game selectedGame)
    {
        SelectedGame = selectedGame;

        Challanges = new(Locator.Current.GetService<ILiteRepository>().Query<Challange>().ToEnumerable());
        
        HeaderButtons.Add(new(MaterialIconKind.Add, null, null));
    }
}