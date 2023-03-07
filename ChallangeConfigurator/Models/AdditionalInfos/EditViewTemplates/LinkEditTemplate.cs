using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Media;

namespace ChallangeConfigurator.Models.AdditionalInfos.EditViewTemplates;

public class LinkEditTemplate : IDataTemplate
{
    public Control Build(object param)
    {
        var model = (LinkAdditionalInfo) param;
        
        var stackPanel = new StackPanel();
        stackPanel.Spacing = 2;

        var labelTb = new TextBox
        {
            Watermark = "Label",
            UseFloatingWatermark = true,
            Text = model.Label,
            FontSize = 15,
        };

        stackPanel.Children.Add(labelTb);

        var urlTb = new TextBox
        {
            Watermark = "URL",
            UseFloatingWatermark = true,
            Text = model.URL,
            FontSize = 15,
        };

        labelTb.TextChanged += (s, e) => { model.Label = labelTb.Text; };
        urlTb.TextChanged += (s, e) => { model.URL = urlTb.Text; };

        stackPanel.Children.Add(urlTb);

        return new Border
        {
            Child = stackPanel,
            BorderBrush = Brushes.Black,
            BorderThickness = new(1),
            Padding = new(2)
        };
    }

    public bool Match(object data)
    {
        return data is LinkAdditionalInfo;
    }
}