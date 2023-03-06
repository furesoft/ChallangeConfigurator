using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;
using DynamicData.Tests;

namespace ChallangeConfigurator.Core.Templates;

public class ListItemTemplate : IDataTemplate
{
    public Control? Build(object? param)
    {
        var grid = new Grid();

        var model = (BaseNameModel)param;
        
        var text = new TextBlock();
        text.HorizontalAlignment = HorizontalAlignment.Left;
        text.VerticalAlignment = VerticalAlignment.Center;
        text.FontSize = 22;
        text.Text = model.Name;
            
        grid.Children.Add(text);
            
        if (param is NamedImageModel nmodel)
        {
            nmodel.LoadImage();
            
            var img = new Image
            {
                Source = nmodel.Image,
                Width = 50,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            text.HorizontalAlignment = HorizontalAlignment.Center;
            
            grid.Children.Add(img);
            
        }

        return grid;
    }

    public bool Match(object? data)
    {
        return data is BaseNameModel;
    }
}