using System;
using System.Collections.Generic;
using System.Linq;

namespace TabuSearch
{
    public class LADS : IProblem
    {
        public List<int> SolutionArray { get; private set; }
        public int SolutionLength { get; }

        public List<List<double>> AutocorrelationProducts { get; set; }  //T(s)

        public List<double> Autocorrelations { get; set; }             //C(s)

        public LADS(int solutionLength = 10)
        {
            SolutionLength = solutionLength;
            SolutionArray = new List<int>();
        }

        public double CalculateFitness()
        {
            CalculateAperiodicAutocorrelation();
            double energy = Autocorrelations.Sum();

            return energy;
        }

        public void GenerateRandomSolution()
        {
            SolutionArray = new List<int>();
            var rand = new Random();
            for (var i = 0; i < SolutionLength; i++)
            {
                SolutionArray.Add(rand.Next(0, 2) == 0 ? -1 : 1);
            }
        }

        private void CalculateAperiodicAutocorrelation()
        {
            AutocorrelationProducts = new List<List<double>>();
            Autocorrelations = new List<double>();
            for (var k = 1; k < SolutionLength; k++)
            {
                AutocorrelationProducts.Add(new List<double>());
                for (var i = 0; i < SolutionLength - k; i++)
                {
                    var product = SolutionArray[i] * SolutionArray[i + k];
                    AutocorrelationProducts[k-1].Add(product);
                }

                Autocorrelations.Add(AutocorrelationProducts[k-1].Sum());
            }
        }
    }
}
