using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_and_data_structures
{
    class Program
    {
        static void Main(string[] args)
        {
            int [,] adjacencyMatrix = {
                { 0,  3,  3,  6,  0,  11, 0,  0,  0,  0,  0},
                { 3,  0,  0,  0,  2,  0,  0,  0,  0,  5,  0},
                { 3,  0,  0,  0,  0,  0,  5,  11, 0,  0,  3},
                { 6,  0,  0,  0,  0,  0,  0,  0,  5,  0,  5},
                { 0,  2,  0,  0,  0,  0,  0,  5,  0,  9,  0},
                { 11, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                { 0,  0,  5,  0,  0,  0,  0,  3,  0,  0,  0},
                { 0,  0,  11, 0,  5,  0,  3,  0,  0,  0,  0},
                { 0,  0,  0,  5,  0,  0,  0,  0,  0,  0,  0},
                { 0,  5,  0,  0,  9,  0,  0,  0,  0,  0,  0},
                { 0,  0,  3,  5,  0,  0,  0,  0,  0,  0,  0}
            };

            var graph = new Graph();
            graph.AdjacencyMatrix = adjacencyMatrix;
            graph.SearchBFS(0); // ожидаемый результат 0  1  2  3  5  4  9  6  7  10 8
            graph.SearchDFS(0); // ожидаемый результат 0  1  4  7  2  6  10 3  8  9  5

            Console.ReadLine();
        }
    }
}
