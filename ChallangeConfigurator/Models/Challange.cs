using System.Collections.Generic;
using ChallangeConfigurator.Core;

namespace ChallangeConfigurator.Models;

public class Challange : BaseNameModel
{
    public IEnumerable<ChallangeRule> Rules { get; set; }
}