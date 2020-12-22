using System;

namespace TabuSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var problem = new LADS();
            problem.GenerateRandomSolution();
            var initialFitness = problem.CalculateFitness();
            Array.ForEach(problem.SolutionArray.ToArray(), (x) => Console.Write($"{x}\t"));
            Console.WriteLine("Initial fitness:\t" + initialFitness);

            var search = new TabuSearch(problem, 200);
            var result = search.Solve();
            var finalFitness = problem.CalculateFitness();
            Array.ForEach(problem.SolutionArray.ToArray(), (x) => Console.Write($"{x}\t"));
            Console.WriteLine("Final fitness:\t\t" + finalFitness);

            Console.WriteLine("Result fitness:\t\t" + result.fitness);
        }
    }
}
