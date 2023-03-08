using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ChallangeConfigurator.Core;
using ChallangeConfigurator.Models;
using LiteDB;
using Material.Icons;
using ReactiveUI;
using Splat;

namespace ChallangeConfigurator.ViewModels.Pages;

public class MainMenuPageViewModel : PageViewModel
{
    private Game _selectedGame;

    public ObservableCollection<Game> Games { get; set; }

    public Game SelectedGame
    {
        get => _selectedGame;
        set
        {
            _selectedGame = value;
            this.RaisePropertyChanged();
            
            NavigateToChallanges(_selectedGame);
        }
    }

    private void NavigateToChallanges(Game selectedGame)
    {
        RoutingState router = Locator.Current.GetService<RoutingState>();

        router.Navigate.Execute(new ChallangesPageViewModel(selectedGame));
    }

    public ICommand NavigateToStatsCommand { get; set; }
    public ICommand AddGameCommand { get; set; }

    public MainMenuPageViewModel()
    {
        //DebugDatabaseBuilder.Build();

        AddGameCommand = ReactiveCommand.Create(() =>
        {
            RoutingState router = Locator.Current.GetService<RoutingState>();

            router.Navigate.Execute(new NewGamePageViewModel());
        });
        
        NavigateToStatsCommand = ReactiveCommand.Create(() =>
        {
            Locator.Current.GetService<RoutingState>().Navigate.Execute(new StatisticsPageViewModel());
        });
        
        HeaderButtons.Add(new(MaterialIconKind.ChartFinance, NavigateToStatsCommand, "Statistik"));
        HeaderButtons.Add(new(MaterialIconKind.LibraryAdd, AddGameCommand, "Neues Spiel"));

        Games = new(Locator.Current.GetService<ILiteRepository>().Query<Game>().ToEnumerable());
    }
}