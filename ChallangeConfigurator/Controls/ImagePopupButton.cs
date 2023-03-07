using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Metadata;
using Material.Icons;
using ReactiveUI;

namespace ChallangeConfigurator.Controls;

public class ImagePopupButton : ToggleButton
{
    public static StyledProperty<MaterialIconKind> KindProperty =
        AvaloniaProperty.Register<ImagePopupButton, MaterialIconKind>(nameof(Kind));

    public static StyledProperty<object> PopupContentProperty =
        AvaloniaProperty.Register<ImagePopupButton, object>(nameof(PopupContent));

    public static StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<ImagePopupButton, string>(nameof(TextProperty));

    public ICommand OpenPopupCommand { get; set; }

    public MaterialIconKind Kind
    {
        get => GetValue(KindProperty);
        set => SetValue(KindProperty, value);
    }
    
    public object PopupContent
    {
        get => GetValue(PopupContentProperty);
        set => SetValue(PopupContentProperty, value);
    }

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public ImagePopupButton()
    {
        OpenPopupCommand = ReactiveCommand.Create(OpenPopup);
    }

    private void OpenPopup()
    {
        IsChecked = !IsChecked;
    }
}
