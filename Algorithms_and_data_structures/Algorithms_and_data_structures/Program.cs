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

        static void Print2(int n, int m, int[,] a)
        {
            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                    Console.Write(a[i, j]);
                Console.Write("\r\n");
            }
        }

        static void Main(string[] args)
        {

            //int i, j;
            //for (j = 0; j < M; j++)
            //    A[0, j] = 1; // Первая строка заполнена единицами
            //for (i = 1; i < N; i++)
            //{
            //    A[i, 0] = 1;
            //    for (j = 1; j < M; j++)
            //        A[i, j] = A[i, j - 1] + A[i - 1, j];
            //}

            //Print2(N, M, A);
            //Console.WriteLine(A[N-1,M-1]);

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
