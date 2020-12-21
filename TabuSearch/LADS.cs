using System;
using System.Collections.Generic;
using System.Text;

namespace TabuSearch
{
    public class LADS : IProblem
    {
        public List<int> SolutionArray { get; }
        public int SolutionLength { get; }
        public int AutocorrelationFactor { get; }

        public LADS(int solutionLength = 10, int autocorrelationFactor = 3)
        {
            SolutionLength = solutionLength;
            SolutionArray = new List<int>();
            AutocorrelationFactor = autocorrelationFactor;
        }

        public double CalculateFitness()
        {
            double energy = 0;
            var autocorrelations = CalculateAperiodicAutocorrelation();
            for (var i = 0; i < AutocorrelationFactor; i++)
            {
                energy += autocorrelations[i] * autocorrelations[i];
            }

            return energy;
        }

        public void GenerateRandomSolution()
        {
            var rand = new Random();
            for (var i = 0; i < SolutionLength; i++)
            {
                SolutionArray.Add(rand.Next(0, 2) == 0 ? -1 : 1);
            }
        }

        private List<double> CalculateAperiodicAutocorrelation()
        {
            var autocorelations = new List<double>();
            for (var i = 0; i < SolutionLength - AutocorrelationFactor; i++)
            {
                autocorelations.Add(SolutionArray[i] * SolutionArray[i + AutocorrelationFactor]);
            }

            return autocorelations;
        }
    }
}
