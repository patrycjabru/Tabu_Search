# Tabu Search
Implementation of a Tabu Search algorithm solving Low Autocorrelation Binary Sequence Problem based on a paper "A Memetic Algorithm for the Low Autocorrelation Binary Sequence Problem" by Jose E. Gallardo, Carlos Cotta and Antonio J. Fernandez from 2007. 
## About algorithm
Tabu search is an algorithm, which searches a local optimum (a minimum in this case). It takes a Problem as an input and returns a solution for which the fitness functions has the lowest value. LABS problem can be represented as an one-dimmensonal fixed size array with values 1 or -1. Solving the problem using Tabu Search is based on flipping values (changing 1 to -1 or -1 to 1) and recalculating the fitness function. In each step one value in the array, which improves the fitness the most, is flipped. After flipping the element of the array, it cannot be flipped again in few next iterations (that is the Tabu from the name).
## Implementation
### LADS.cs - implementation of Low Autocorrelation Binary Sequence Problem
Contains array with solution and method to calculate fitness (energy) of the solution along with intermediary autocorrelation values (called in the paper T(s) and C(s)) used to calculate fitness of flipped solution more effective. 
### TabuSearch.cs - implementation of Tabu Search Algorithm
It takes as a parameter in the constructor maximum number of algorithm iterations, minimum number of tabu iteration and extra tabu iterations. Method Solve() runs the algorithm and returns the best found solution with fitness wrapped in ResultModel object.
### ResultModel.cs - model object for solution
Contains solution with its fitness value and comparison operator overloading.
### SearchRunner.cs - class responsible for running TabuSearch
Runs TabuSearch with proper parameters in a loop with a time constraint. It allows to acquire data needed for an analysis of results. 
### PlotGenerator.cs - class responsible for plot generation
Contains methods to generate box and whiskers plot and series of those plots. Uses Scott Plot library. 
### Program.cs - main class
Contains main code of the program execution. 
## Results
TODO
