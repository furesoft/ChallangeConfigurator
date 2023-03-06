using ChallangeConfigurator.Core;
using ReactiveUI.Fody.Helpers;

namespace ChallangeConfigurator.Models.AdditionalInfos;

public class LinkAdditionalInfo : BaseModel
{
    [Reactive] public string Label { get; set; }
    [Reactive] public string URL { get; set; }
}