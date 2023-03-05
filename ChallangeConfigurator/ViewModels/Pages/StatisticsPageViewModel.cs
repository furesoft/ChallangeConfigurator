using System;
using System.Collections.Generic;
using ChallangeConfigurator.Core;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.Themes;
using ReactiveUI;
using SkiaSharp;

namespace ChallangeConfigurator.ViewModels.Pages;

public class StatisticsPageViewModel : PageViewModel
{
    public StatisticsPageViewModel()
    {
        LiveCharts.Configure(
            settings => settings
                .AddDefaultMappers()
                .AddSkiaSharp()
                .AddDarkTheme(
                    theme =>
                        theme
                            .HasRuleForLineSeries(lineSeries =>
                            {
                                // you can add additional rules to the current theme
                                lineSeries.LineSmoothness = 0.65;
                            })
                            .HasRuleForBarSeries(barSeries =>
                            {
                                // ...
                            })
                ));
        
        var data = new double[] { 2, 4, 1, 4, 3 };

        // Series = data.AsLiveChartsPieSeries(); this could be enough in some cases // mark
        // but you can customize the series properties using the following overload: // mark

        Series = data.AsLiveChartsPieSeries((value, series) =>
        {
            // here you can configure the series assigned to each value.
            series.Name = $"Series for value {value}";
            series.DataLabelsPaint = new SolidColorPaint(new SKColor(30, 30, 30));
            series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle;
            series.DataLabelsFormatter = p => $"{p.PrimaryValue} / {p.StackedValue!.Total} ({p.StackedValue.Share:P2})";
        });
    }
    
    public IEnumerable<ISeries> Series { get; set; }
    public LabelVisual Title { get; set; } =
        new LabelVisual
        {
            Text = "My chart title",
            TextSize = 25,
            Padding = new LiveChartsCore.Drawing.Padding(15),
            Paint = new SolidColorPaint(SKColors.DarkSlateGray)
        };
}