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
Different parameters were checked to find the best possible solution. Extra tabu = 4 and min tabu = 20 were used as initial values, because they were suggested in the paper. 

Best results were achieved for Min Tabu equal 30 (solution length = 100, algorithm runs = 50, search interations = 100, extra tabu = 4). 

![Impact of the Min Tabu parameter value on the solution](https://github.com/patrycjabru/Tabu_Search/blob/master/images/multiple%20results%20min%20tabu.png?raw=true)

Best results were achieved for Extra Tabu equal 15 (solution length = 100, algorithm runs = 50, search interations = 100, min tabu = 20). 

![Impact of the Extra Tabu parameter value on the solution](https://github.com/patrycjabru/Tabu_Search/blob/master/images/multiple%20results%20extra%20tabu.png?raw=true)

Best results were achieved for Search Iteration equal 1000 (solution length = 100, algorithm runs = 100, min tabu = 4, extra tabu = 20). However, we can expect that longer calculation can lead to better results, but extends the calculation time. It means, that there is no optimal value of Search Iteration. But the dependency between Search Iteration and time can be measured this way. 

![Impact of the Extra Tabu parameter value on the solution](https://github.com/patrycjabru/Tabu_Search/blob/master/images/multiple%20results%20iterations%20-%20without%20time.png?raw=true)

Searching with time limit is about calling the algoritm using the same initialy generated solution as many times as can fit in the time limit. Here is the result of the run with time limit 60s (solution length = 100, algorithm runs = 20, search interations = 100, min tabu = 20, extra tabu = 4).

![Impact of the Extra Tabu parameter value on the solution](https://github.com/patrycjabru/Tabu_Search/blob/master/images/multiple%20results%20iterations%20-%2060s%205.png?raw=true)

Here is the result of the run with time limit 60s (solution length = 100, algorithm runs = 10, search interations = 100, min tabu = 20, extra tabu = 4).

![Impact of the Extra Tabu parameter value on the solution](https://github.com/patrycjabru/Tabu_Search/blob/master/images/multiple%20results%20iterations%20-%2060s%202.png?raw=true)

Here is the result of the run with time limit 120s (solution length = 100, algorithm runs = 50, search interations = 100, min tabu = 20, extra tabu = 4).

![Impact of the Extra Tabu parameter value on the solution](https://github.com/patrycjabru/Tabu_Search/blob/master/images/multiple%20results%20iterations%20-%20120s.png?raw=true)

## Summary
There is hard to draw a conclusion. whether it is better to run the algorithm many times but shorter or few times but longer. There should be at least 500 iteration to allow the algorithm to find some good solution and it probably will improve a little over time, but there is no significant different seen on a plot. 

