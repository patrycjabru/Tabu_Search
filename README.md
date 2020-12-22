# Tabu Search
Implementation of a Tabu Search algorithm solving Low Autocorrelation Binary Sequence Problem based on a paper "A Memetic Algorithm for the Low Autocorrelation Binary Sequence Problem" by Jose E. Gallardo, Carlos Cotta and Antonio J. Fernandez from 2007. 
## About algorithm
Tabu search is an algorithm, which searches a local optimum (a minimum in this case). It takes a Problem as an input and returns a solution for which the fitness functions has the lowest value. LABS problem can be represented as an one-dimmensonal fixed size array with values 1 or -1. Solving the problem using Tabu Search is based on flipping values (changing 1 to -1 or -1 to 1) and recalculating the fitness function. In each step one value in the array, which improves the fitness the most, is flipped. After flipping the element of the array, it cannot be flipped again in few next iterations (that is the Tabu from the name).
## Implementation
TODO
