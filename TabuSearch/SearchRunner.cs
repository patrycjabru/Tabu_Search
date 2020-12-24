using System;
using System.Collections.Generic;
using System.Text;

namespace TabuSearch
{
    public class SearchRunner
    {
        public List<(List<int> solution, double fitness)> Run(int iterations, IProblem problem, ISolver solver)
        {
            var results = new List<(List<int> solution, double fitness)>();
            for (var i = 0; i < iterations; i++)
            {
                var result = solver.Solve(new LADS(problem));
                results.Add(result);
            }

            return results;

        }
    }
}
