using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace ChallangeConfigurator.Assets.Controls;

public class EditableContainer : ContentControl
{
    public static readonly StyledProperty<bool> IsEditModeProperty =
        AvaloniaProperty.Register<EditableContainer, bool>(nameof(IsEditMode));

    public static readonly StyledProperty<object> EditModeContentProperty =
        AvaloniaProperty.Register<EditableContainer, object>(nameof(EditModeContent));

    public bool IsEditMode
    {
        get => GetValue(IsEditModeProperty);
        set => SetValue(IsEditModeProperty, value);
    }
    
    public object EditModeContent
    {
        get => GetValue(EditModeContentProperty);
        set => SetValue(EditModeContentProperty, value);
    }

    //ToDo: DeleteCommand
    //ToDo: AcceptCommand
}