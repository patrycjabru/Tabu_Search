using System;
using System.Collections.Generic;
using System.Text;

namespace TabuSearch
{
    public class ResultModel
    {
        public List<int> Solution { get; set; }
        public double Fitness { get; set; }

        public ResultModel()
        {
            this.Solution = new List<int>();
            this.Fitness = double.MaxValue;
        }
        public ResultModel(List<int> solution, double fitness)
        {
            this.Solution = solution;
            this.Fitness = fitness;
        }

        public static bool operator >(ResultModel a, ResultModel b) => a.Fitness < b.Fitness;

        public static bool operator <(ResultModel a, ResultModel b) => a.Fitness > b.Fitness;
    }
}
