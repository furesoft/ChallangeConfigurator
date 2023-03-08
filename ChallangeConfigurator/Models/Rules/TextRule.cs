using ReactiveUI.Fody.Helpers;

namespace ChallangeConfigurator.Models.Rules;

public class TextRule : ChallangeRule
{
    [Reactive] public string Text { get; set; }

    public TextRule()
    {
        Name = "Text";
    }
}