using System;
using System.Collections.Generic;
using System.Linq;

namespace TabuSearch
{
    public class LADS : IProblem
    {
        public List<int> SolutionArray { get; set; }
        public int SolutionLength { get; }

        public List<List<double>> AutocorrelationProducts { get; set; }  //T(s)

        public List<double> Autocorrelations { get; set; }               //C(s)

        public LADS(int solutionLength = 10)
        {
            SolutionLength = solutionLength;
            SolutionArray = new List<int>();
        }

        public LADS(IProblem problem)
        {
            this.SolutionArray = problem.SolutionArray;
            this.SolutionLength = problem.SolutionArray.Count;
        }

        public double CalculateFitness()
        {
            CalculateAperiodicAutocorrelation();
            var energy = 0.0;
            foreach (var c in Autocorrelations)
            {
                energy += c * c;
            }

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
