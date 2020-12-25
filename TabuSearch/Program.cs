﻿using System;
using System.Collections.Generic;
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
            var plotGenerator = new PlotGenerator();

            //var results = runner.Run(100, problem, search, 200);
            //plotGenerator.GenerateSingleBoxAndWhiskers(results, "results");

            var algorithmRuns = 200;
            var searchIterations = new List<int>() {100, 200, 300, 400, 500};
            var multipleResultsIterations = runner.RunWithMultipleIterations(algorithmRuns, problem, search, searchIterations, 20, 4);
            plotGenerator.GenerateMultipleBoxAndWhiskers(multipleResultsIterations, searchIterations, "Solution energy for different values of search iterations", "multiple results iterations");

            var minTabus = new List<int>(){10, 20, 30, 40, 50};
            var multipleResultsMinTabu = runner.RunWithMultipleMinTabu(algorithmRuns, problem, search, 100, minTabus, 4);
            plotGenerator.GenerateMultipleBoxAndWhiskers(multipleResultsMinTabu, searchIterations, "Solution energy for different values of min tabu", "multiple results min tabu");

            var extraTabus = new List<int>(){5, 10, 15, 20, 25};
            var multipleResultsExtraTabu = runner.RunWithMultipleExtraTabu(algorithmRuns, problem, search, 100, 20, extraTabus);
            plotGenerator.GenerateMultipleBoxAndWhiskers(multipleResultsExtraTabu, searchIterations, "Solution energy for different values of extra tabu", "multiple results extra tabu");


            

        }
    }
}
