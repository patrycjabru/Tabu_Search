using System;
using ScottPlot;

namespace TabuSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var problem = new LADS(100);
            problem.GenerateRandomSolution();

            var search = new TabuSearch(200, 20, 4);

            var runner = new SearchRunner();
            var results = runner.Run(100, problem, search);

            var plotGenerator = new PlotGenerator();
            plotGenerator.GenerateSinglePlotAndWhiskers(results, "results");
        }
    }
}
