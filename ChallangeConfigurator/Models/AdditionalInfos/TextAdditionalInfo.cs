using ChallangeConfigurator.Core;
using ReactiveUI.Fody.Helpers;

namespace ChallangeConfigurator.Models.AdditionalInfos;

public class TextAdditionalInfo : BaseModel
{
    [Reactive] public string Text { get; set; }
}