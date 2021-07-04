using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_and_data_structures
{
    class Program
    {
        const int N = 2000;
        const int M = 1000;

        static void Main(string[] args)
        {
            Console.WriteLine($"Колличество путей для поля {N}x{M} равняется: {CountPuth(N, M)}");
            Console.ReadLine();
        }

        static int CountPuth(int n,int m)
        {
            int[,] array = new int[n, m];
            for (int i = 0; i < n; i++)
                array[i, 0] = 1;
            
            for (int i = 0; i < m; i++)
                array[0, i] = 1;

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    array[i, j] = array[i - 1, j] + array[i, j - 1];
                }
            }
            return array[n-1, m-1];
        }
    }
}
