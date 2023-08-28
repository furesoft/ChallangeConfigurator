using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using ChallangeConfigurator.Models.AdditionalInfos;

namespace ChallangeConfigurator.Core.Converters;

public class SocialIconConverter : MarkupExtension, IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null)
        {
            value = SocialIconKind.Facebook;
        }

        var iconName = GetIconName(Enum.Parse<SocialIconKind>(value.ToString()));
        
        return new Bitmap(AssetLoader.Open(new($"avares://ChallangeConfigurator/Assets/SocialIcons/{iconName}.png"), null));
    }

    private string GetIconName(SocialIconKind value)
    {
        return value.ToString().ToLower();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return new SocialIconConverter();
    }
}