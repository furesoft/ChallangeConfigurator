using System.Diagnostics;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using ReactiveUI;

namespace ChallangeConfigurator.Controls;

public class Link : Button
{
    public static StyledProperty<TextDecorationCollection> TextDecorationsProperty =
        AvaloniaProperty.Register<Link, TextDecorationCollection>(nameof(TextDecorations));

    public static StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<Link, string>(nameof(Title));

    public static StyledProperty<string> URLProperty =
        AvaloniaProperty.Register<Link, string>(nameof(URL));

    public TextDecorationCollection TextDecorations
    {
        get => GetValue(TextDecorationsProperty);
        set => SetValue(TextDecorationsProperty, value);
    }

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string URL
    {
        get => GetValue(URLProperty);
        set => SetValue(URLProperty, value);
    }

    public Link()
    {
        Command = ReactiveCommand.Create(OpenLink);
    }

    private void OpenLink()
    {
        try
        {
            Process.Start(URL);
        }
        catch
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                URL = URL.Replace("&", "^&");
                Process.Start(new ProcessStartInfo("cmd", $"/c start {URL}") {CreateNoWindow = true});
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", URL);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", URL);
            }
            else
            {
                throw;
            }
        }
    }
}