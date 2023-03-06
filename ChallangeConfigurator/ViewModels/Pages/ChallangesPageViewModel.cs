using System.Collections.ObjectModel;
using System.Linq;
using ChallangeConfigurator.Core;
using ChallangeConfigurator.Models;
using ChallangeConfigurator.Models.AdditionalInfos;
using ChallangeConfigurator.Models.AdditionalInfos.Layout;
using LiteDB;
using Material.Icons;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace ChallangeConfigurator.ViewModels.Pages;

public class ChallangesPageViewModel : PageViewModel
{
    public Game SelectedGame { get; }

    public ObservableCollection<Challange> Challanges { get; set; }

    [Reactive] public bool IsEditMode { get; set; }
    
    public ChallangesPageViewModel(Game selectedGame)
    {
        SelectedGame = selectedGame;

        Challanges = new(Locator.Current.GetService<ILiteRepository>().Query<Challange>().ToEnumerable());
        
        HeaderButtons.Add(new(MaterialIconKind.Edit, ReactiveCommand.Create(SetEditMode), "Spiel bearbeiten"));
        HeaderButtons.Add(new(MaterialIconKind.Add, null, null));

        PutAdditionalLinksIntoStackLayout();
    }

    private void PutAdditionalLinksIntoStackLayout()
    {
        if (!SelectedGame.AdditionalInfos.OfType<LinkAdditionalInfo>().Any())
        {
            return;
        }
        
        var addInfos = SelectedGame.AdditionalInfos.ToArray();
        
        SelectedGame.AdditionalInfos.Clear();

        var layout = new AdditionalInfoHorizontalLayout(){ Items = new() };

        foreach (var addInfo in addInfos)
        {
            if (addInfo is LinkAdditionalInfo)
            {
                layout.Items.Add(addInfo);
                continue;
            }

            SelectedGame.AdditionalInfos.Add(addInfo);
        }
        
        SelectedGame.AdditionalInfos.Add(layout);
    }

    private void SetEditMode()
    {
        IsEditMode = !IsEditMode;
    }
}