using ChallangeConfigurator.Core;
using ChallangeConfigurator.Models.AdditionalInfos;
using ReactiveUI.Fody.Helpers;

namespace ChallangeConfigurator.Models;

public abstract class ChallangeRule : EditableModel
{
    [Reactive] public string DescriptionTemplate { get; set; }
}