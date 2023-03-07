using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;

namespace ChallangeConfigurator.Models.AdditionalInfos.EditViewTemplates;

public class TextEditTemplate : IDataTemplate
{
    public Control Build(object param)
    {
        var model = (TextAdditionalInfo)param;
        
        var labelTb = new TextBox();
        labelTb.Watermark = "Text";
        labelTb.UseFloatingWatermark = true;
        
        labelTb.TextChanged += (s, e) => { model.Text = labelTb.Text; };
        labelTb.Text = model.Text;

        return labelTb;
    }

    public bool Match(object data)
    {
        return data is LinkAdditionalInfo;
    }
}