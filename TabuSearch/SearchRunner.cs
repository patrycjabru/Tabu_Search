using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace TabuSearch
{
    public class SearchRunner
    {
        public List<ResultModel> Run(int iterations, IProblem problem, ISolver solver, int searchIterations, int minTabu, int extraTabu)
        {
            var maxSeconds = 60;
            var results = new List<ResultModel>();
            solver.MaxIterations = searchIterations;
            solver.MinTabu = minTabu;
            solver.ExtraTabu = extraTabu;
            var stopWatch = new Stopwatch();
            for (var i = 0; i < iterations; i++)
            {
                stopWatch.Start();
                Console.WriteLine($"Algorithm run number {i}");
                var bestResult = new ResultModel();
                var numberOfTries = 0;
                while (stopWatch.Elapsed.TotalSeconds < maxSeconds)
                {
                    numberOfTries++;
                    var result = solver.Solve(new LADS(problem));
                    if (result > bestResult)
                        bestResult = result;
                }
                stopWatch.Stop();
                stopWatch.Restart();
                Console.WriteLine($"Number of tries {numberOfTries} for max iterations {searchIterations}");
                results.Add(bestResult);
            }

            return results;

        }

        public List<List<ResultModel>> RunWithMultipleIterations(int iterations,
            IProblem problem, ISolver solver, List<int> searchIterationsList, int minTabu, int extraTabu)
        {
            var output = new List<List<ResultModel>>();
            foreach (var i in searchIterationsList)
            {
                var results = Run(iterations, new LADS(problem), solver, i, minTabu, extraTabu);
                output.Add(results);
            }

            return output;
        }

        public List<List<ResultModel>> RunWithMultipleMinTabu(int iterations, IProblem problem, ISolver solver, int searchIteration,
            List<int> minTabuList, int extraTabu)
        {
            var output = new List<List<ResultModel>>();
            foreach (var i in minTabuList)
            {
                var results = Run(iterations, new LADS(problem), solver, searchIteration, i, extraTabu);
                output.Add(results);
            }

            return output;
        }

        public List<List<ResultModel>> RunWithMultipleExtraTabu(int iterations, IProblem problem, ISolver solver, int searchIteration,
            int minTabu, List<int> extraTabu)
        {
            var output = new List<List<ResultModel>>();
            foreach (var i in extraTabu)
            {
                var results = Run(iterations, new LADS(problem), solver, searchIteration, minTabu, i);
                output.Add(results);
            }

            return output;
        }
    }
}
