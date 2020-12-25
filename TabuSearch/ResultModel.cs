using System;
using System.Collections.Generic;
using System.Text;

namespace TabuSearch
{
    public class ResultModel
    {
        public List<int> Solution { get; set; }
        public double Fitness { get; set; }

        public ResultModel(List<int> solution, double fitness)
        {
            this.Solution = solution;
            this.Fitness = fitness;
        }
    }
}
