using System;
using System.Collections.Generic;
using System.Text;

namespace TabuSearch
{
    public interface ISolver
    {
        public int MaxIterations { get; set; }
        public int ExtraTabu { get; set; }
        public int MinTabu { get; set; }
        public ResultModel Solve(IProblem problem);
    }
}
