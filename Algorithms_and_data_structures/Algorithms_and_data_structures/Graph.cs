using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_and_data_structures
{
    public interface IGraph
    {
        void SearchDFS(int startPosition);
        void SearchBFS(int startPosition); 
    }

    class Graph : IGraph
    {
        public int[,] AdjacencyMatrix { get; set; }
        public void SearchBFS(int startPosition)// поиск в ширину
        {
            Console.WriteLine("Запущен поиск в ширину");
            var queue = new Queue<int>();
            Console.WriteLine($"Положили в очередь начальную позицию {startPosition}");
            queue.Enqueue(startPosition);
            int graphNode;
            bool[] node = new bool[AdjacencyMatrix.GetLength(0)]; //массив для понимания в каких узлах мы уже были
            node[startPosition] = true; 
            //для удобного вывода обхода графа
            int[] bypassOrder = new int[AdjacencyMatrix.GetLength(0)];
            int count = 0;
            bypassOrder[count] = startPosition;
            do
            {
                graphNode = queue.Dequeue();
                Console.WriteLine($"Забрали из очереди узел {graphNode}");
                for (int j = 0; j < AdjacencyMatrix.GetLength(0); j++)
                {
                    if (AdjacencyMatrix[graphNode, j] != 0)
                    {
                        if (node[j] == false)
                        {
                            queue.Enqueue(j);
                            Console.WriteLine($"Положили в очередь узел {j}");
                            node[j] = true;
                            count += 1;
                            bypassOrder[count] = j;
                        }
                    }
                }
            } while (queue.Count != 0);
            Console.Write("Обход графа в ширину закончен, порядок обхода:");
            foreach (int item in bypassOrder)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();
        }

        public void SearchDFS(int startPosition) // поиск в глубину
        {
            Console.WriteLine("Запущен поиск в глубину");
            var stack = new Stack<int>();
            stack.Push(startPosition);
            int graphNode;
            bool[] node = new bool[AdjacencyMatrix.GetLength(0)]; //массив для понимания в каких узлах мы уже были
            //для удобного вывода обхода графа
            int[] bypassOrder = new int[AdjacencyMatrix.GetLength(0)];
            int count = 0;
            bypassOrder[count] = startPosition;
            do
            {
                graphNode = stack.Pop();
                if (node[graphNode] == false) // проверка были ли мы уже в этом узле 
                {
                    node[graphNode] = true;
                    bypassOrder[count] = graphNode;
                    count += 1;
                    Console.WriteLine($"Забрали из стека узел {graphNode}");
                    for (int j = AdjacencyMatrix.GetLength(0) - 1; j >= 0; j--)
                    {
                        if (AdjacencyMatrix[graphNode, j] != 0)
                                stack.Push(j);
                    }
                }
            } while (stack.Count != 0);
            Console.Write("Обход графа в глубину закончен, порядок обхода:");
            foreach (int item in bypassOrder)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();
        }
    }
}
