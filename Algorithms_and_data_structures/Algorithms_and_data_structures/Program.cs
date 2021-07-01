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
            var tree = new Tree();
            int countElement = 20;
            var newNumber = new Random(17);

            for (int i = 0; i < countElement; i++)
            {
                tree.AddItem(newNumber.Next(1, countElement));
            }
            var number = newNumber.Next(1, countElement);
            tree.SearchBFS(number);
            Console.WriteLine();
            tree.SearchDFS(number);

            Console.ReadLine();
        }
    }
}
