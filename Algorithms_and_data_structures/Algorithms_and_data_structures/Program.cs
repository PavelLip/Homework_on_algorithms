using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_and_data_structures
{
    class Program
    {
        public class TestCase
        {
            public string Number { get; set; }
            public int Expected { get; set; }
        }
        static void Main(string[] args)
        {
            // Задание №1
            var testCase1_1 = new TestCase { Number = "22", Expected = 4 };
            var testCase1_2 = new TestCase { Number = "3001", Expected = 2 };
            var testCase1_3 = new TestCase { Number = "7", Expected = 2 };
            var testCase1_4 = new TestCase { Number = "12 2", Expected = 0 };
            var testCase1_5 = new TestCase { Number = "dsfsd", Expected = 0 };

            TestNumber(testCase1_1);
            TestNumber(testCase1_2);
            TestNumber(testCase1_3);
            TestNumber(testCase1_4);
            TestNumber(testCase1_5);

            // Задание №2
            var testCase2_1 = new TestCase { Number = "22", Expected = 17711 };
            var testCase2_2 = new TestCase { Number = "11", Expected = 89 };
            var testCase2_3 = new TestCase { Number = "7", Expected = 13 };
            var testCase2_4 = new TestCase { Number = "12 2", Expected = 0 };
            var testCase2_5 = new TestCase { Number = "dsfsd", Expected = 0 };

            TestFibonacciRecursion(testCase2_1);
            TestFibonacciRecursion(testCase2_2);
            TestFibonacciRecursion(testCase2_3);
            TestFibonacciRecursion(testCase2_4);
            TestFibonacciRecursion(testCase2_5);

            TestFibonacciCycle(testCase2_1);
            TestFibonacciCycle(testCase2_2);
            TestFibonacciCycle(testCase2_3);
            TestFibonacciCycle(testCase2_4);
            TestFibonacciCycle(testCase2_5);

            Console.ReadLine();
        }

        // Задание №1
        static void TestNumber(TestCase testCase)
        {
            try
            {
                NumberOfDivisors(int.Parse(testCase.Number));
                Console.WriteLine("VALID TEST");
            }
            catch (Exception)
            {
                Console.WriteLine("INVALID TEST");
            }

        }
        static void NumberOfDivisors(int n)
        {
            int d = 2;
            int i = 2;

            while (i < n) 
            {
                if (n % i == 0)
                    d++;
                i++;
            };

            if (d == 0)
                Console.WriteLine("Простое");
            else
                Console.WriteLine("Не простое");
        }

        // Задание №2
        // Общая асимптотическая сложность алгоритма O(2+N^2*3N)
        // можно упростить до O(N^3)
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;                                            //O(1)
            for (int i = 0; i < inputArray.Length; i++)             //O(N)
            {
                for (int j = 0; j < inputArray.Length; j++)             //O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++)             //O(N)
                    {
                        int y = 0;                                              //O(1)

                        if (j != 0)                                             //O(1)
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y;                   //O(1)
                    }
                }
            }

            return sum;                                             //O(1)
        }

        static int FibonacciNumbersRecursion(int countNamber)
        {
            if (countNamber == 1 || countNamber == 2)
                return 1;
            
            else
                return (FibonacciNumbersRecursion(countNamber-2) + FibonacciNumbersRecursion(countNamber-1));
        }

        static int FibonacciNumbersCycle(int countNamber)
        {
            int finishNumber;
            int firstNumber = 0, secondNumber = 1;
            if (countNamber == 1)
            {
                //Console.WriteLine($"Значение числа фибоначи равняется {firstNumber}");
                finishNumber = firstNumber;
            }

            else if (countNamber == 2)
            {
                finishNumber = secondNumber;
                //Console.WriteLine($"Значение числа фибоначи равняется {secondNumber}");
            }
            else
            {
                int newNumber;
                for (int i = 2; i < countNamber; i++)
                {
                    newNumber = firstNumber + secondNumber;
                    firstNumber = secondNumber;
                    secondNumber = newNumber;
                }
                finishNumber = secondNumber;
                //Console.WriteLine($"Значение числа фибоначи равняется {secondNumber}");
            }
            return finishNumber;
        }
        static void TestFibonacciRecursion(TestCase testCase)
        {
            try
            {
                int acactual = FibonacciNumbersRecursion(Convert.ToInt32(testCase.Number));
                if (acactual == testCase.Expected)
                    Console.WriteLine("VALID TEST");
                else
                    Console.WriteLine("INVALID TEST");
            }
            catch (Exception)
            {
                Console.WriteLine("VALID EXCEPTION TEST");
            }
        }
        static void TestFibonacciCycle(TestCase testCase)
        {
            try
            {
                int acactual = FibonacciNumbersCycle(Convert.ToInt32(testCase.Number));
                if (acactual == testCase.Expected)
                    Console.WriteLine("VALID TEST");
                else
                    Console.WriteLine("INVALID TEST");
            }
            catch (Exception)
            {
                Console.WriteLine("VALID EXCEPTION TEST");
            }
        }
    }
}