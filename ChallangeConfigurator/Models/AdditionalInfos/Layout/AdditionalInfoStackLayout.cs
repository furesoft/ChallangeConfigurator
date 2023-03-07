using System.Collections.ObjectModel;
using Avalonia.Layout;
using ChallangeConfigurator.Core;
using ChallangeConfigurator.Models.AdditionalInfos.EditViewTemplates;
using ReactiveUI.Fody.Helpers;

namespace ChallangeConfigurator.Models.AdditionalInfos.Layout;

public class AdditionalInfoStackLayout : EditableModel
{
    public AdditionalInfoStackLayout()
    {
        Items = new();

        EditViewTemplate = new StackLayoutEditTemplate();
    }

    [Reactive] public Orientation Orientation { get; set; }

    [Reactive] public ObservableCollection<BaseModel> Items { get; set; }
}