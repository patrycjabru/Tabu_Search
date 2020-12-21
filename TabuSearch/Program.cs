namespace TabuSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var problem = new LADS();
            problem.GenerateRandomSolution();
            var initialFitness = problem.CalculateFitness();

            var search = new TabuSearch(problem, 200);
            var result = search.Solve();
            var finalFitness = problem.CalculateFitness();
        }
    }
}
