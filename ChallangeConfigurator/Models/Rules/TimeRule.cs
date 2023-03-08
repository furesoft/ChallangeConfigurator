using System;
using System.Net.Mime;
using ReactiveUI.Fody.Helpers;

namespace ChallangeConfigurator.Models.Rules;

public class TimeRule : ChallangeRule
{
    [Reactive] public TimeOnly Time { get; set; }

    public TimeRule()
    {
        Name = "Zeit";
    }
}