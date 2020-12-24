using System;
using System.Collections.Generic;
using System.Text;

namespace TabuSearch
{
    public interface ISolver
    {
        public (List<int> solution, double fitness) Solve(IProblem problem);
    }
}
