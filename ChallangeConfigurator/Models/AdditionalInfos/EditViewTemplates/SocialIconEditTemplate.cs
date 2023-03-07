using System;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;
using Avalonia.Media.Imaging;
using ChallangeConfigurator.Core.Converters;
using Brushes = Avalonia.Media.Brushes;

namespace ChallangeConfigurator.Models.AdditionalInfos.EditViewTemplates;

public class SocialIconEditTemplate : IDataTemplate
{
    public Control Build(object param)
    {
        var model = (SocialIconAdditionalInfo) param;
        
        var stackPanel = new StackPanel();
        stackPanel.Spacing = 2;
        stackPanel.Orientation = Orientation.Horizontal;

        var iconCb = new ComboBox()
        {
            Items = Enum.GetNames<SocialIconKind>(),
            SelectedIndex = (int)model.Icon,
            FontSize = 15,
            Width = 40,
        };
        
        iconCb.ItemTemplate = new FuncDataTemplate(_ => true, (o, scope) =>
        {
            var img = (IBitmap)new SocialIconConverter().Convert(o, GetType(), o, CultureInfo.InvariantCulture);

            return new Image() { Source = img, Width = 35, Height = 35 };
        });

        stackPanel.Children.Add(iconCb);

        var urlTb = new TextBox
        {
            Watermark = "URL",
            UseFloatingWatermark = true,
            Text = model.Url,
            FontSize = 15,
            MinWidth = 150,
        };
        urlTb.Loaded += (s, e) =>
        {
            urlTb.Focus();
        };
        
        iconCb.SelectionChanged += (s, e) => { model.Icon = (SocialIconKind)iconCb.SelectedIndex; };
        urlTb.TextChanged += (s, e) => { model.Url = urlTb.Text; };

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
        return data is SocialIconAdditionalInfo;
    }
}