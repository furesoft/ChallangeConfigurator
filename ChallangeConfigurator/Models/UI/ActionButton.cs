using System.Windows.Input;
using Material.Icons;

namespace ChallangeConfigurator.Models.UI;

public class ActionButton
{
    public ActionButton(MaterialIconKind kind, ICommand command, string tooltip)
    {
        Kind = kind;
        Command = command;
        Tooltip = tooltip;
    }

    public MaterialIconKind Kind { get; set; }
    public ICommand Command { get; set; }

    public string Tooltip { get; set; }
}