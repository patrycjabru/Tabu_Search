using System;
using System.Collections.Generic;
using System.Text;
using ScottPlot;

namespace TabuSearch
{
    public class PlotGenerator
    {
        public void GenerateSingleBoxAndWhiskers(List<ResultModel> results, string plotName = "results")
        {
            var plt = new Plot(600, 400);

            var ys = new double[results.Count];
            var i = 0;
            foreach (var r in results)
            {
                ys[i] = r.Fitness;
                i++;
            }

            plt.Title("Solution energy");
            plt.YLabel("Solution energy");

            var pop = new ScottPlot.Statistics.Population(ys);
            plt.PlotPopulations(pop, "scores");

            plt.SaveFig($"{plotName}.png");
        }

        public void GenerateMultipleBoxAndWhiskers(List<List<ResultModel>> allResults, List<int> xValues, string plotTitle, string plotName = "results")
        {
            var plt = new ScottPlot.Plot(600, 400);

            var poulations = new ScottPlot.Statistics.Population[allResults.Count];
            var p = 0;
            foreach (var results in allResults)
            {
                var ys = new double[results.Count];
                var i = 0;
                foreach (var r in results)
                {
                    ys[i] = r.Fitness;
                    i++;
                }
                var pop = new ScottPlot.Statistics.Population(ys);
                poulations[p] = pop;
                p++;
            }

            var popSeries = new ScottPlot.Statistics.PopulationSeries(poulations);
            plt.PlotPopulations(popSeries, "scores");

            // improve the style of the plot
            plt.Title(plotTitle);
            plt.YLabel("Solution energy");

            var ticks = new string[xValues.Count];
            var j = 0;
            foreach(var iterations in xValues)
            {
                ticks[j] = iterations.ToString();
                j++;
            }
            plt.XTicks(ticks);
            plt.Legend();
            plt.Grid(lineStyle: LineStyle.Dot, enableVertical: false);

            plt.SaveFig($"{plotName}.png");
        }
    }
}
