using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TabuSearch
{
    public class TabuSearch : ISolver
    {
        public int MaxIterations { get; set; }
        public int ExtraTabu { get; set; }
        public int MinTabu { get; set; }

        public TabuSearch(int maxIterations, int minTabu = 20, int extraTabu = 4)
        {
            this.MaxIterations = maxIterations;
            this.MinTabu = minTabu;
            this.ExtraTabu = extraTabu;
        }

        public ResultModel Solve(IProblem problem)
        {
            //start timer
            var rand = new Random();
            var tabuList = CreateEmptyTabuList(problem);

            var solution = new List<int>(problem.SolutionArray);
            var fitness = problem.CalculateFitness();

            for (var k = 1; k <= MaxIterations; k++)
            {
                var bestMove = FindBestMove(problem, k, tabuList, fitness);
                problem.SolutionArray = bestMove.bestSolutionInIteration; 
                problem.CalculateFitness();
                tabuList[bestMove.bestIndexInIteration-1] = k + MinTabu + rand.Next(ExtraTabu);

                if (!(bestMove.bestFitnessInIteration < fitness)) continue;

                solution = bestMove.bestSolutionInIteration;
                fitness = bestMove.bestFitnessInIteration;
            }

            problem.SolutionArray = solution;

            return new ResultModel(solution, fitness);
        }

        private (double bestFitnessInIteration, List<int> bestSolutionInIteration, int bestIndexInIteration) FindBestMove(IProblem problem, int iteration, List<int> tabuList, double fitness)
        {
            var bestFitnessInIteration = double.MaxValue;
            var bestSolutionInIteration = problem.SolutionArray;
            var bestIndexInIteration = 1;

            for (var i = 1; i <= bestSolutionInIteration.Count; i++)
            {
                var possibleSolution = Flip(problem, i);
                var possibleFitness = ValueFlip(problem, i);
                if ((iteration < tabuList[i - 1] && !(possibleFitness < fitness)) ||
                    (!(possibleFitness < bestFitnessInIteration))) continue;

                bestFitnessInIteration = possibleFitness;
                bestSolutionInIteration = possibleSolution;
                bestIndexInIteration = i;
            }

            return (bestFitnessInIteration, bestSolutionInIteration, bestIndexInIteration);
        }

        private List<int> CreateEmptyTabuList(IProblem problem)
        {
            var tabuList = new List<int>();
            for (var i = 0; i < problem.SolutionArray.Count; i++)
            {
                tabuList.Add(0);
            }

            return tabuList;
        }
        private double ValueFlip(IProblem problem, int valueIndex)
        {
            var fitness = 0.0;
            for (var p = 0; p < problem.SolutionArray.Count - 1; p++)
            {
                var value = problem.Autocorrelations[p];
                if (p < problem.SolutionArray.Count - valueIndex)
                {
                    value -= 2 * problem.AutocorrelationProducts[p][valueIndex - 1];
                }

                if (p < valueIndex - 1)
                {
                    value -= 2 * problem.AutocorrelationProducts[p][valueIndex - 1 - p - 1];
                }

                fitness += value * value;
            }
            return fitness;
        }
        private List<int> Flip(IProblem problem, int index)
        {
            var flippedSolution = new List<int>(problem.SolutionArray);
            flippedSolution[index-1] *= -1;

            return flippedSolution;
        }


    }
}
