using System;
using System.Collections.Generic;
using System.Text;

namespace TabuSearch
{
    class TabuSearch
    {
        public IProblem Problem { get; }

        public TabuSearch(IProblem problem)
        {
            this.Problem = problem;
        }

        public double ValueFlip(int valueIndex)
        {
            var f = 0.0;
            for (var p = 0; p < Problem.SolutionArray.Count - 1; p++)
            {
                var v = Problem.Autocorrelations[p];
                if (p < Problem.SolutionArray.Count - valueIndex)
                {
                    v = v - 2 * Problem.AutocorrelationProducts[p][valueIndex - 1];
                }

                if (p < valueIndex - 1)
                {
                    v = v - 2 * Problem.AutocorrelationProducts[p][valueIndex - 1 - p];
                }

                f += v * v;
            }
            return f;
        }

        public void Solve()
        {

        }
    }
}
