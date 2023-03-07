using System;
using Avalonia.Markup.Xaml;
using ChallangeConfigurator.Controls;
using ChallangeConfigurator.Models.AdditionalInfos;
using ReactiveUI;

namespace ChallangeConfigurator.Core.MarkupExtensions;

public class OpenLinkExtension : MarkupExtension
{
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return ReactiveCommand.Create<SocialIconAdditionalInfo>(_ =>
        {
            Link.OpenLink(_.Url.ToString());
        });
    }
}