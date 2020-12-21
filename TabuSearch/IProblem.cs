using System;
using System.Collections.Generic;
using System.Text;

namespace TabuSearch
{
    interface IProblem
    {
        public List<int> SolutionArray { get; }
        double CalculateFitness();
        void GenerateRandomSolution();
    }
}
