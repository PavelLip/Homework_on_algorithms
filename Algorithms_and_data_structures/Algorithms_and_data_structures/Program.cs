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
            public string number { get; set; }
            public int Expected { get; set; }
        }
        static void Main(string[] args)
        {
            // Задание №1
            var testCase1_1 = new TestCase { number = "22", Expected = 4 };
            var testCase1_2 = new TestCase { number = "3001", Expected = 2 };
            var testCase1_3 = new TestCase { number = "7", Expected = 2 };
            var testCase1_4 = new TestCase { number = "12 2", Expected = 0 };
            var testCase1_5 = new TestCase { number = "dsfsd", Expected = 0 };

            TestNumber(testCase1_1);
            TestNumber(testCase1_2);
            TestNumber(testCase1_3);
            TestNumber(testCase1_4);
            TestNumber(testCase1_5);

            // Задание №2
            var testCase2_1 = new TestCase { number = "22", Expected = 10946 };
            var testCase2_2 = new TestCase { number = "11", Expected = 55 };
            var testCase2_3 = new TestCase { number = "7", Expected = 8 };
            var testCase2_4 = new TestCase { number = "12 2", Expected = 0 };
            var testCase2_5 = new TestCase { number = "dsfsd", Expected = 0 };

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
                var acactual = NumberOfDivisors(testCase.number);
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
        static int NumberOfDivisors(string number)
        {
            int n = Convert.ToInt32(number);
            int d = 2;
            int i = 2;

            do
            {
                if (n % i == 0)
                    d++;
                i++;
            } while (i < n);

            if (d == 0)
                Console.WriteLine("Простое");
            else
                Console.WriteLine($"Не простое, кол-во делителей = {d}");
            return d;
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
            int firstNumber = 0, secondNumber = 1;
            int finishNumber;
            if (countNamber == 1)
            {
                finishNumber = firstNumber;
                //Console.WriteLine($"Значение числа фибоначи равняется {firstNumber}");
            }
            else if (countNamber == 2)
            {
                //Console.WriteLine($"Значение числа фибоначи равняется {secondNumber}");
                finishNumber = secondNumber;
            }
            else
            {
                (firstNumber, secondNumber) = RecursionFibonacci(firstNumber, secondNumber, countNamber);
                finishNumber = secondNumber;
                //Console.WriteLine($"Значение числа фибоначи равняется {secondNumber}");
            }
            return finishNumber;
        }
        static (int, int) RecursionFibonacci(int firstNumber, int secondNumber, int countNamber)
        {
            if (countNamber <= 2)
            {
                firstNumber = 0;
                secondNumber = 1;
                return (firstNumber, secondNumber);
            }
            else
            {
                countNamber -= 1;
                (firstNumber, secondNumber) = RecursionFibonacci(firstNumber, secondNumber, countNamber);
                int newNumber = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = newNumber;
                return (firstNumber, secondNumber);
            }
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
                int acactual = FibonacciNumbersRecursion(Convert.ToInt32(testCase.number));
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
                int acactual = FibonacciNumbersCycle(Convert.ToInt32(testCase.number));
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