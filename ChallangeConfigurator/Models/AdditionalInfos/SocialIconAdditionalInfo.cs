using ChallangeConfigurator.Models.AdditionalInfos.EditViewTemplates;
using ReactiveUI.Fody.Helpers;

namespace ChallangeConfigurator.Models.AdditionalInfos;

public enum SocialIconKind
{
    Facebook,
    Instagram,
    Twitter,
    Youtube,
}

public class SocialIconAdditionalInfo : AdditionalInfoModel
{
    [Reactive] public SocialIconKind Icon { get; set; }
    [Reactive] public string Url { get; set; }

    public SocialIconAdditionalInfo()
    {
        EditViewTemplate = new SocialIconEditTemplate();
        Name = "Social";
    }
}