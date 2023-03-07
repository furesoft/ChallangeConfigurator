using Avalonia.Controls;
using Avalonia.Controls.Templates;
using ChallangeConfigurator.Models.AdditionalInfos;

namespace ChallangeConfigurator.Core;

public class ModelTemplateSelector : IDataTemplate
{
    public Control Build(object param)
    {
        var model = (EditableModel) param;

        return model.EditViewTemplate.Build(model);
    }

    public bool Match(object data)
    {
        var model = (EditableModel) data;

        return model.EditViewTemplate != null;
    }
}