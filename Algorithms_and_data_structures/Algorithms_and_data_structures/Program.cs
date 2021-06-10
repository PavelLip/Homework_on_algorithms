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
            public LinkedList list { get; set; }
            public string number { get; set; }
            public int index { get; set; }
            public int Expectedcount { get; set; }
            public Node _node { get; set; }
            public Node ExpectedNode { get; set; }
            public int ExpectedValue { get; set; }
        }
        static void Main(string[] args)
        {
            LinkedList ls = new LinkedList();

            var testCase1_1_1 = new TestCase { number = "1", list = ls};
            var testCase1_1_2 = new TestCase { number = "2", list = ls };
            var testCase1_1_3 = new TestCase { number = "3", list = ls };
            var testCase1_1_4 = new TestCase { number = "4 4", list = ls };
            var testCase1_1_5 = new TestCase { number = "sdfs", list = ls };

            Console.WriteLine("Тест на добавление данных: ");
            TestAddNode(testCase1_1_1);
            TestAddNode(testCase1_1_2);
            TestAddNode(testCase1_1_3);
            TestAddNode(testCase1_1_4);
            TestAddNode(testCase1_1_5);

            var testCase1_2_1 = new TestCase { number = "1", list = ls , ExpectedValue = 1};
            var testCase1_2_2 = new TestCase { number = "2", list = ls , ExpectedValue = 2 };
            var testCase1_2_3 = new TestCase { number = "3", list = ls , ExpectedValue = 3 };
            var testCase1_2_4 = new TestCase { number = "6 6", list = ls , ExpectedValue = 0 };
            var testCase1_2_5 = new TestCase { number = "df", list = ls , ExpectedValue = 0 };

            Console.WriteLine("Тест на поиск по значению данных: ");
            TestFindNode(testCase1_2_1);
            TestFindNode(testCase1_2_2);
            TestFindNode(testCase1_2_3);
            TestFindNode(testCase1_2_4);
            TestFindNode(testCase1_2_5);

            var testCase1_3_1 = new TestCase { number = "4", list = ls, _node = ls.head};
            var testCase1_3_2 = new TestCase { number = "5", list = ls, _node = ls.tail };
            var testCase1_3_3 = new TestCase { number = "6", list = ls, _node = ls.head.NextNode };
            var testCase1_3_4 = new TestCase { number = "7 4", list = ls, _node = ls.tail };
            var testCase1_3_5 = new TestCase { number = "df", list = ls, _node = ls.head };

            Console.WriteLine("Тест на добавление после значения: ");
            TestAddNodeAfter(testCase1_3_1);
            TestAddNodeAfter(testCase1_3_2);
            TestAddNodeAfter(testCase1_3_3);
            TestAddNodeAfter(testCase1_3_4);
            TestAddNodeAfter(testCase1_3_5);

            var testCase1_4_1 = new TestCase { Expectedcount = 5, list = ls, _node = ls.tail };
            var testCase1_4_2 = new TestCase { Expectedcount = 4, list = ls, _node = ls.head };
            var testCase1_4_3 = new TestCase { Expectedcount = 3, list = ls, _node = ls.head.NextNode };
            var testCase1_4_4 = new TestCase { Expectedcount = 2, list = ls, _node = ls.tail };
            var testCase1_4_5 = new TestCase { Expectedcount = 1, list = ls, _node = ls.head };

            Console.WriteLine("Тест на удаление по Node: ");
            TestRemoveNode(testCase1_4_1);
            TestRemoveNode(testCase1_4_2);
            TestRemoveNode(testCase1_4_3);
            TestRemoveNode(testCase1_4_4);
            TestRemoveNode(testCase1_4_5);

            var testCase1_5_1 = new TestCase { Expectedcount = 2, list = ls, index = 3 };
            var testCase1_5_2 = new TestCase { Expectedcount = 1, list = ls, index = 2 };
            var testCase1_5_3 = new TestCase { Expectedcount = 0, list = ls, index = 1 };
            var testCase1_5_4 = new TestCase { Expectedcount = -1, list = ls, index = 7 };
            var testCase1_5_5 = new TestCase { Expectedcount = -2, list = ls, index = -7 };

            Console.WriteLine("Тест на удаление по индексу: ");
            TestRemoveNodeIndex(testCase1_5_1);
            TestRemoveNodeIndex(testCase1_5_2);
            TestRemoveNodeIndex(testCase1_5_3);
            TestRemoveNodeIndex(testCase1_5_4);
            TestRemoveNodeIndex(testCase1_5_5);

            var testCase1_6_1 = new TestCase { Expectedcount = 0, list = ls};
            var testCase1_6_2 = new TestCase { Expectedcount = 0, list = ls};
            var testCase1_6_3 = new TestCase { Expectedcount = 0, list = ls};
            var testCase1_6_4 = new TestCase { Expectedcount = 1, list = ls};
            var testCase1_6_5 = new TestCase { Expectedcount = 2, list = ls};

            Console.WriteLine("Тест кол-во элементов: ");
            TestGetCount(testCase1_6_1);
            TestGetCount(testCase1_6_2);
            TestGetCount(testCase1_6_3);
            TestGetCount(testCase1_6_4);
            TestGetCount(testCase1_6_5);

            int[] mArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };

            var testCase2_1 = new TestCase { number = "1", ExpectedValue = 1 };
            var testCase2_2 = new TestCase { number = "21", ExpectedValue = 21 };
            var testCase2_3 = new TestCase { number = "10", ExpectedValue = 10 };
            var testCase2_4 = new TestCase { number = "1 1"};
            var testCase2_5 = new TestCase { number = "fdg" };

            Console.WriteLine("Тест на бинарный поиск: ");
            TestBinarySearch(testCase2_1, mArray);
            TestBinarySearch(testCase2_2, mArray);
            TestBinarySearch(testCase2_3, mArray);
            TestBinarySearch(testCase2_4, mArray);
            TestBinarySearch(testCase2_5, mArray);


            Console.ReadLine();

        }

        static string BinarySearch(int[] array, int desiredValue)
        {
            int segmentLength = array.Length / 2;
            int middle = array.Length / 2;
            for (int i = 0; i < array.Length/2; i++)
            {
                if (array[middle - 1] == desiredValue)
                    return Convert.ToString(middle);
                else if (middle != array.Length  && array[middle] == desiredValue)
                    return Convert.ToString(middle + 1);
                else if (middle - 1 != -1 && array[middle-2] == desiredValue)
                    return Convert.ToString(middle - 1);
                else if (array[middle-1] < desiredValue)
                {
                    if (segmentLength / 2 == 0)
                        segmentLength = 1;
                    else
                        segmentLength = segmentLength / 2;
                    middle = middle + segmentLength;

                }
                else if (array[middle - 1] > desiredValue)
                {
                    if (segmentLength / 2 == 0)
                        segmentLength = 1;
                    else
                        segmentLength = segmentLength / 2;
                    middle = middle - segmentLength;
                }
            }
            return null;
        }
        static void TestAddNode(TestCase testCase)
        {
            try
            {
                testCase.list.AddNode(Convert.ToInt32(testCase.number));
                Console.WriteLine("VALID TEST");
            }
            catch (Exception)
            {
                Console.WriteLine("VALID EXCEPTION TEST");
            }

        }
        static void TestAddNodeAfter(TestCase testCase)
        {
            try
            {
                testCase.list.AddNodeAfter(testCase._node, Convert.ToInt32(testCase.number));
                    Console.WriteLine("VALID TEST");
            }
            catch (Exception)
            {
                Console.WriteLine("VALID EXCEPTION TEST");
            }

        }
        static void TestGetCount(TestCase testCase)
        {
            try
            {
                var acactual = testCase.Expectedcount;
                if (acactual == testCase.list.GetCount())
                    Console.WriteLine("VALID TEST");
                else
                    Console.WriteLine("INVALID TEST");
            }
            catch (Exception)
            {
                Console.WriteLine("VALID EXCEPTION TEST");
            }

        }
        static void TestFindNode(TestCase testCase)
        {
            try
            {
                var t = testCase.list.FindNode(Convert.ToInt32(testCase.number));
                if (t == null || t.Value == testCase.ExpectedValue)
                    Console.WriteLine("VALID TEST");
                else
                    Console.WriteLine("INVALID TEST");
            }
            catch (Exception)
            {
                Console.WriteLine("VALID EXCEPTION TEST");
            }

        }
        static void TestRemoveNodeIndex(TestCase testCase)
        {
            try
            {
                testCase.list.RemoveNode(testCase.index);
                int acactual = testCase.list.GetCount();
                if (acactual == testCase.Expectedcount)
                    Console.WriteLine("VALID TEST");
                else
                    Console.WriteLine("INVALID TEST");
            }
            catch (Exception)
            {
                Console.WriteLine("VALID EXCEPTION TEST");
            }

        }
        static void TestRemoveNode(TestCase testCase)
        {
            try
            {
                testCase.list.RemoveNode(testCase._node);
                int acactual = testCase.list.GetCount();
                if (acactual == testCase.Expectedcount)
                    Console.WriteLine("VALID TEST");
                else
                    Console.WriteLine("INVALID TEST");
            }
            catch (Exception)
            {
                Console.WriteLine("VALID EXCEPTION TEST");
            }

        }
        static void TestBinarySearch (TestCase testCase, int [] array)
        {
            try
            {
                int acactual = testCase.ExpectedValue;

                if (acactual == Convert.ToInt32(BinarySearch(array, Convert.ToInt32(testCase.number))))
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
