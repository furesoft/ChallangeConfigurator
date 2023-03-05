using System.Collections.Generic;
using ChallangeConfigurator.Core;

namespace ChallangeConfigurator.Models;

public class Challange : BaseModel
{
    public string Name { get; set; }
    public IEnumerable<ChallangeRule> Rules { get; set; }
}