using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ChallangeConfigurator.Core;
using ChallangeConfigurator.Models;
using ChallangeConfigurator.Models.AdditionalInfos;
using ChallangeConfigurator.Models.AdditionalInfos.Layout;
using DynamicData;
using LiteDB;
using Material.Icons;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace ChallangeConfigurator.ViewModels.Pages;

public class ChallangesPageViewModel : PageViewModel
{
    private object _selectedAdditionalInfoType;
    public Game SelectedGame { get; }

    public ObservableCollection<Challange> Challanges { get; set; }
    public ObservableCollection<object> AdditionalInfoTypes { get; set; }

    public object SelectedAdditionalInfoType
    {
        get => _selectedAdditionalInfoType;
        set
        {
            this.RaisePropertyChanged();

            if (value == null)
            {
                return;
            }

            var additionalInfoModel = (AdditionalInfoModel) Activator.CreateInstance(value.GetType());

            AddAditionalInfo(additionalInfoModel);

            IsAddPopupOpen = false;
            SelectedAdditionalInfoType = null;
        }
    }

    private void AddAditionalInfo(AdditionalInfoModel additionalInfoModel)
    {
        /*if (additionalInfoModel is LinkAdditionalInfo)
        {
            var stack = (AdditionalInfoStackLayout)SelectedGame.AdditionalInfos.FirstOrDefault(_ => _ is AdditionalInfoStackLayout);

            if (stack is null)
            {
                stack = new AdditionalInfoHorizontalLayout();
            }
            
            stack.Items.Add(additionalInfoModel);
        }
        else
        {*/
            SelectedGame.AdditionalInfos.Add(additionalInfoModel);
        //}
    }

    [Reactive] public bool IsEditMode { get; set; }

    [Reactive] public ICommand ApplyChangesCommand { get; set; }

    [Reactive] public bool IsAddPopupOpen { get; set; }

    public ChallangesPageViewModel(Game selectedGame)
    {
        SelectedGame = selectedGame;

        Challanges = new(Locator.Current.GetService<ILiteRepository>().Query<Challange>().ToEnumerable());

        HeaderButtons.Add(new(MaterialIconKind.Edit, ReactiveCommand.Create(SetEditMode), "Spiel bearbeiten"));
        HeaderButtons.Add(new(MaterialIconKind.Add, null, "Information hinzufügen"));

        PutAdditionalLinksIntoStackLayout<LinkAdditionalInfo>();
        PutAdditionalLinksIntoStackLayout<SocialIconAdditionalInfo>();

        ApplyChangesCommand = ReactiveCommand.Create<BaseModel, BaseModel>(ApplyChanges);

        AdditionalInfoTypes = new(GetType().Assembly
            .GetTypes()
            .Where(_ => _.IsAssignableTo(typeof(AdditionalInfoModel)))
            .Select(_ => (AdditionalInfoModel) Activator.CreateInstance(_))
            .Where(_ => _.Name != null)
        );
    }

    private BaseModel ApplyChanges(BaseModel model)
    {
        IsEditMode = false;
        //ToDo: implement updating game info

        return model;
    }

    private void PutAdditionalLinksIntoStackLayout<T>()
        where T : AdditionalInfoModel
    {
        if (!SelectedGame.AdditionalInfos.OfType<T>().Any())
        {
            return;
        }

        var addInfos = SelectedGame.AdditionalInfos.ToArray();

        SelectedGame.AdditionalInfos.Clear();

        var layout = new AdditionalInfoHorizontalLayout() {Items = new()};

        foreach (var addInfo in addInfos)
        {
            if (addInfo is T)
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