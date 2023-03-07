using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;

namespace ChallangeConfigurator.Assets.Controls;

public class EditableContainer : ContentControl
{
    public static readonly StyledProperty<bool> IsEditModeProperty =
        AvaloniaProperty.Register<EditableContainer, bool>(nameof(IsEditMode));

    public static readonly StyledProperty<bool> IsDeleteableProperty =
        AvaloniaProperty.Register<EditableContainer, bool>(nameof(IsDeleteable), true);

    public static readonly StyledProperty<object> EditModeContentProperty =
        AvaloniaProperty.Register<EditableContainer, object>(nameof(EditModeContent));

    public static readonly StyledProperty<object> CommandParameterProperty =
        AvaloniaProperty.Register<EditableContainer, object>(nameof(CommandParameter));

    public static readonly StyledProperty<ICommand> DeleteCommandProperty =
        AvaloniaProperty.Register<EditableContainer, ICommand>(nameof(DeleteCommand));

    public bool IsEditMode
    {
        get => GetValue(IsEditModeProperty);
        set => SetValue(IsEditModeProperty, value);
    }

    public bool IsDeleteable
    {
        get => GetValue(IsDeleteableProperty);
        set => SetValue(IsDeleteableProperty, value);
    }

    public ICommand DeleteCommand
    {
        get => GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }

    public object EditModeContent
    {
        get => GetValue(EditModeContentProperty);
        set => SetValue(EditModeContentProperty, value);
    }

    public object CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }
}