using System;
using System.Collections.Generic;
using System.Text;

namespace TabuSearch
{
    class TabuSearch
    {
        public IProblem Problem { get; }
        public int MaxIterations { get; }

        public TabuSearch(IProblem problem, int maxIterations)
        {
            this.Problem = problem;
            this.MaxIterations = maxIterations;
        }

        public double ValueFlip(int valueIndex)
        {
            var f = 0.0;
            for (var p = 0; p < Problem.SolutionArray.Count - 1; p++)
            {
                var v = Problem.Autocorrelations[p];
                if (p < Problem.SolutionArray.Count - valueIndex)
                {
                    v -= 2 * Problem.AutocorrelationProducts[p][valueIndex - 1];
                }

                if (p < valueIndex - 1)
                {
                    v -= 2 * Problem.AutocorrelationProducts[p][valueIndex - 1 - p - 1];
                }

                f += v * v;
            }
            return f;
        }

        public (List<int> solution, double fitness) Solve()
        {
            var rand = new Random();
            var m = new List<double>();
            for (var i = 0; i < Problem.SolutionArray.Count; i++)
            {
                m.Add(0);
            }

            var minTabu = MaxIterations / 10;
            var extraTabu = MaxIterations / 50;

            var solution = new List<int>(Problem.SolutionArray);
            var fitness = Problem.CalculateFitness();

            for (var k = 1; k <= MaxIterations; k++)
            {
                var bestFitness = double.MaxValue;
                var bestSolution = Problem.SolutionArray;
                var bestIndex = 1;

                for (var i = 1; i <= solution.Count; i++)
                {
                    var possibleSolution = Flip(i);
                    var possibleFitness= ValueFlip(i);
                    if (k >= m[i-1] || possibleFitness < fitness)
                    {
                        if (possibleFitness < bestFitness)
                        {
                            bestFitness = possibleFitness;
                            bestSolution = possibleSolution;
                            bestIndex = i;
                        }
                    }
                }
                Problem.SolutionArray = bestSolution;
                Problem.CalculateFitness();
                m[bestIndex-1] = k + minTabu + rand.Next(extraTabu);
                if (bestFitness < fitness)
                {
                    solution = bestSolution;
                    fitness = bestFitness;
                }
            }

            return (solution, fitness);
        }

        public List<int> Flip(int index)
        {
            var flippedSolution = new List<int>(Problem.SolutionArray);
            flippedSolution[index-1] *= -1;

            return flippedSolution;
        }
    }
}
