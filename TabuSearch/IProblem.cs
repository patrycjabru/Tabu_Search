using System;
using System.Collections.Generic;
using System.Text;

namespace TabuSearch
{
    public interface IProblem
    {
        List<int> SolutionArray { get; set; }
        List<List<double>> AutocorrelationProducts { get; set; }
        List<double> Autocorrelations { get; set; }             
        double CalculateFitness();
        void GenerateRandomSolution();
    }
}
