using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;
using DynamicData.Tests;

namespace ChallangeConfigurator.Core.Templates;

public class ListItemTemplate : IDataTemplate
{
    public Control? Build(object? param)
    {
        if (param is NamedImageModel model)
        {
            model.LoadImage();
            
            var grid = new Grid();

            var img = new Image
            {
                Source = model.Image,
                Width = 50,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            
            grid.Children.Add(img);

            var text = new TextBlock();
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            text.FontSize = 22;
            text.Text = model.Name;
            
            grid.Children.Add(text);
            
            return grid;
        }

        return null;
    }

    public bool Match(object? data)
    {
        return data is NamedImageModel;
    }
}