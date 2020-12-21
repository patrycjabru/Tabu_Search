using System;

namespace TabuSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var problem = new LADS();
            problem.GenerateRandomSolution();
            problem.CalculateFitness();
        }
    }
}
