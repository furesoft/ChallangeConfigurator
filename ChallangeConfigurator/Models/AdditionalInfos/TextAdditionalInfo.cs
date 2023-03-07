using Avalonia.Controls;
using ChallangeConfigurator.Models.AdditionalInfos.EditViewTemplates;
using ReactiveUI.Fody.Helpers;

namespace ChallangeConfigurator.Models.AdditionalInfos;

public class TextAdditionalInfo : EditableModel
{
    [Reactive] public string Text { get; set; }

    public TextAdditionalInfo()
    {
        EditViewTemplate = new TextEditTemplate();
    }
}