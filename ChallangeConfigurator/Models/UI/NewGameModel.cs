using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ChallangeConfigurator.Models.UI;

public class NewGameModel : ReactiveObject
{
    [Reactive] public string Name { get; set; }
    [Reactive] public string ImageFilename { get; set; }
}