using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace TabuSearch
{
    public class SearchRunner
    {
        public List<ResultModel> Run(int iterations, IProblem problem, ISolver solver, int searchIterations, int minTabu, int extraTabu)
        {
            var results = new List<ResultModel>();
            solver.MaxIterations = searchIterations;
            solver.MinTabu = minTabu;
            solver.ExtraTabu = extraTabu;
            for (var i = 0; i < iterations; i++)
            {
                var result = solver.Solve(new LADS(problem));
                results.Add(result);
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
