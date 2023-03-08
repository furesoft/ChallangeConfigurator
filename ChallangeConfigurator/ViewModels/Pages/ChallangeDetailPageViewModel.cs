using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ChallangeConfigurator.Core;
using ChallangeConfigurator.Models;
using ChallangeConfigurator.Models.AdditionalInfos;
using Material.Icons;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ChallangeConfigurator.ViewModels.Pages;

public class ChallangeDetailPageViewModel : PageViewModel
{
    private ChallangeRule _selectedRule;
    
    public Challange SelectedChallange { get; }
    
    [Reactive] public bool IsEditMode { get; set; }

    [Reactive] public ICommand ApplyChangesCommand { get; set; }

    [Reactive] public bool IsAddPopupOpen { get; set; }
    
    public ObservableCollection<object> RuleTypes { get; set; }
    

    public ChallangeDetailPageViewModel(Challange selectedChallange)
    {
        SelectedChallange = selectedChallange;
        
        HeaderButtons.Add(new(MaterialIconKind.Edit, ReactiveCommand.Create(SetEditMode), "Challange bearbeiten"));
        
        RuleTypes = new(GetType().Assembly
            .GetTypes()
            .Where(_ => _.IsAssignableTo(typeof(ChallangeRule)) && !_.IsAbstract)
            .Select(_ => (ChallangeRule) Activator.CreateInstance(_))
            .Where(_ => _.Name != null)
        );
        
        ApplyChangesCommand = ReactiveCommand.Create<BaseModel>(ApplyChanges);
    }
    
    public object SelectedRule
    {
        get => _selectedRule;
        set
        {
            this.RaisePropertyChanged();

            if (value == null)
            {
                return;
            }

            var rule = (ChallangeRule) Activator.CreateInstance(value.GetType());

            SelectedChallange.Rules.Add(rule);

            IsAddPopupOpen = false;
            SelectedRule = null;
        }
    }
    
    private void SetEditMode()
    {
        IsEditMode = !IsEditMode;
    }
    
    private void ApplyChanges(BaseModel model)
    {
        IsEditMode = false;
        //ToDo: implement updating game info

    }
}