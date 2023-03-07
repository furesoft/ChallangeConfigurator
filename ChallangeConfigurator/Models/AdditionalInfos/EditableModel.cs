using Avalonia.Controls.Templates;
using ChallangeConfigurator.Core;
using LiteDB;

namespace ChallangeConfigurator.Models.AdditionalInfos;

public abstract class EditableModel : BaseNameModel
{
    [BsonIgnore] public IDataTemplate EditViewTemplate { get; set; }
}