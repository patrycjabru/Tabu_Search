using System;
using System.Collections.Generic;
using System.Text;
using ScottPlot;

namespace TabuSearch
{
    public class PlotGenerator
    {
        public void GenerateSinglePlotAndWhiskers(List<(List<int> solution, double fitness)> results, string plotName = "results")
        {
            var plt = new Plot(600, 400);

            var ys = new double[results.Count];
            var i = 0;
            foreach (var r in results)
            {
                ys[i] = r.fitness;
                i++;
            }

            plt.Title("Solution energy");
            plt.YLabel("Solution energy");

            var pop = new ScottPlot.Statistics.Population(ys);
            plt.PlotPopulations(pop, "scores");

            plt.SaveFig("Results.png");
        }
    }
}
