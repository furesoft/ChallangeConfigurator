using Avalonia.Controls;
using Avalonia.Media;
using ChallangeConfigurator.Models.AdditionalInfos.EditViewTemplates;
using ReactiveUI.Fody.Helpers;

namespace ChallangeConfigurator.Models.AdditionalInfos;

public class LinkAdditionalInfo : AdditionalInfoModel
{
    [Reactive] public string Label { get; set; }
    [Reactive] public string URL { get; set; }

    public LinkAdditionalInfo()
    {
        EditViewTemplate = new LinkEditTemplate();

        Name = "Link";
    }
}