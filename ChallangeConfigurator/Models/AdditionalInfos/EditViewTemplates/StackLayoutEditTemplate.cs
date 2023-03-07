using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;
using Avalonia.Media;
using ChallangeConfigurator.Assets.Controls;
using ChallangeConfigurator.Models.AdditionalInfos.Layout;
using ReactiveUI;

namespace ChallangeConfigurator.Models.AdditionalInfos.EditViewTemplates;

public class StackLayoutEditTemplate : IDataTemplate
{
    public Control Build(object param)
    {
        var m = (AdditionalInfoStackLayout) param;

        var deleteCommand = ReactiveCommand.Create<EditableModel>(mm =>
        {
            var items = m.Items.ToList();
            var index = m.Items.IndexOf(mm);

            items.RemoveAt(index);

            m.Items = new(items);
        });

        var stackPanel = new StackPanel
        {
            Orientation = Orientation.Horizontal,
            Spacing = 5
        };

        foreach (var c in m.Items)
        {
            var model = (EditableModel) c;
            stackPanel.Children.Add(new EditableContainer
            {
                EditModeContent = model.EditViewTemplate != null ? model.EditViewTemplate.Build(model) : model,
                Content = model.EditViewTemplate != null ? model.EditViewTemplate.Build(model) : model,
                CommandParameter = model,
                IsEditMode = true,
                DeleteCommand = deleteCommand
            });
        }

        return new Border
        {
            Child = stackPanel,
            BorderBrush = Brushes.Black,
            BorderThickness = new(1),
            Padding = new(5)
        };
    }

    public bool Match(object data)
    {
        return data is AdditionalInfoStackLayout;
    }
}