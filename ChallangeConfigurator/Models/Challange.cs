using System.Collections.Generic;
using System.Collections.ObjectModel;
using ChallangeConfigurator.Core;

namespace ChallangeConfigurator.Models;

public class Challange : BaseNameModel
{
    public ObservableCollection<ChallangeRule> Rules { get; set; }

    public Challange()
    {
        Rules = new();
    }
}