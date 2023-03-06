using System.Collections.ObjectModel;
using ChallangeConfigurator.Core;
using ReactiveUI.Fody.Helpers;

namespace ChallangeConfigurator.Models;

public class Game : NamedImageModel
{
    [Reactive] public ObservableCollection<BaseModel> AdditionalInfos { get; set; }
}