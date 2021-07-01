using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Algorithms_and_data_structures
{
    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

            Tree t = new Tree();
            int countElementTree = 25;
            Random rnd = new Random();
            t.AddItem(10);
            for (int i = 0; i < countElementTree; i++)
            {
                t.AddItem(rnd.Next(0, 21));
            }
            t.PrintTree();

            Console.ReadLine();
        }
    }

    public class BechmarkClass
    {
        HashSet<string> hashSet { get; set; }
        string[] arrayStr { get; set; }

        public bool SelectArray(string[] array, string soughtStr)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == soughtStr)
                    return true;
            }
            return false;
        }

        public bool SelectHash(HashSet<string> hashSetStr, string soughtStrHash)
        {
            if (hashSetStr.Contains(soughtStrHash))
            {
                return true;
            }
            return false;
        }

        [GlobalSetup]
        public void TestTest()
        {
            Random random = new Random();
            int countStr = 10000;
            int lengthStr = 20;
            arrayStr = new string[countStr];
            hashSet = new HashSet<string>();

            for (int i = 0; i < countStr; i++)
            {
                string str = null;
                for (int j = 0; j < lengthStr; j++)
                {
                    str += Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))).ToString();
                }
                arrayStr[i] = str;
                hashSet.Add(str);
            }
        }

        [Benchmark]
        public void SelectArray()
        {
            for (int i = 0; i < 1; i++)
                SelectArray(arrayStr, arrayStr[i * 900]);
        }

        [Benchmark]
        public void SelectHash()
        {
            for (int i = 0; i < 1; i++)
            {
                string str = arrayStr[i * 900];
                SelectHash(hashSet, str);
            }
        }
    }
}