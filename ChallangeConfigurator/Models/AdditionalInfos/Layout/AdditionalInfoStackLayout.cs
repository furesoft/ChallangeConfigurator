using System.Collections.ObjectModel;
using Avalonia.Layout;
using ChallangeConfigurator.Core;
using ReactiveUI.Fody.Helpers;

namespace ChallangeConfigurator.Models.AdditionalInfos.Layout;

public class AdditionalInfoStackLayout : BaseModel
{
    [Reactive] public Orientation Orientation { get; set; }

    public ObservableCollection<BaseModel> Items { get; set; }
}