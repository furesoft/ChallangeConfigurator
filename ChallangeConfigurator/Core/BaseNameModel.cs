using ReactiveUI.Fody.Helpers;

namespace ChallangeConfigurator.Core;

public class BaseNameModel : BaseModel
{
   [Reactive] public string Name { get; set; }
}