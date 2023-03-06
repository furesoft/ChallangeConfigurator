using System.IO;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using ChallangeConfigurator.Core;
using ChallangeConfigurator.Models;
using ChallangeConfigurator.Models.UI;
using LiteDB;
using Material.Icons;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace ChallangeConfigurator.ViewModels.Pages;

public class NewGamePageViewModel : PageViewModel
{
    [Reactive] public NewGameModel Game { get; set; }
    [Reactive] public IBitmap Image { get; set; }

    [Reactive] public bool HasImageSet { get; set; }

    public NewGamePageViewModel()
    {
        Game = new();
        
        HeaderButtons.Add(new(MaterialIconKind.Done, ReactiveCommand.Create(OK), "OK"));
    }

    private void OK()
    {
        var repository = Locator.Current.GetService<ILiteRepository>();
        var router = Locator.Current.GetService<RoutingState>();

        var game = new Game();
        game.Name = Game.Name;
        game._id = ObjectId.NewObjectId();

        repository.Database.FileStorage.Upload(game._id.ToString(), game._id.ToString(),
            File.OpenRead(Game.ImageFilename));

        repository.Insert(game);

        router.NavigateBack.Execute();
        
        ((MainMenuPageViewModel)router.CurrentViewModel).Games.Add(game);
    }
}