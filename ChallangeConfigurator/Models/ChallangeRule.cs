using ChallangeConfigurator.Core;
using ReactiveUI.Fody.Helpers;

namespace ChallangeConfigurator.Models;

public abstract class ChallangeRule : BaseNameModel
{
    [Reactive] public string DescriptionTemplate { get; set; }
}