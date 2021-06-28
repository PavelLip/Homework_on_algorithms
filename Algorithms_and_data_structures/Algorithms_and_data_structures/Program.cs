using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Algorithms_and_data_structures
{
    public class Str
    {
        public string RndString { get; set; }

        public override bool Equals(object obj)
        {
            var str = obj as Str;
            if (RndString == null)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            int rndStringHashCode = RndString?.GetHashCode() ?? 0;
            return rndStringHashCode;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

            Tree t = new Tree();

            int countElementTree = 100;
            Console.SetBufferSize(3000, 300);

            Random rnd = new Random();
            t.AddItem(50);
            for (int i = 0; i < countElementTree; i++)
            {
                t.AddItem(rnd.Next(0,101));
            }

            t.PrintTree();
            Console.ReadLine();



            //t.AddItem(8);
            //t.AddItem(4);
            //t.AddItem(12);
            //t.AddItem(2);
            //t.AddItem(6);
            //t.AddItem(10);
            //t.AddItem(14);
            //t.AddItem(1);
            //t.AddItem(3);
            //t.AddItem(5);
            //t.AddItem(7);
            //t.AddItem(9);
            //t.AddItem(11);
            //t.AddItem(13);
            //t.AddItem(15);

            //t.PrintTree();

            ////t.GetNodeByValue(9);
            ////t.GetNodeByValue(1);
            ////t.GetNodeByValue(3);
            ////t.GetNodeByValue(4);
            ////t.GetNodeByValue(8);


            //t.RemoveItem(9);
            //t.PrintTree();
            //t.RemoveItem(12);
            //t.PrintTree();
            //t.RemoveItem(8);
            //t.PrintTree();
            //t.RemoveItem(4);
            //t.PrintTree();



            Console.ReadLine();
        }
    }
        public class BechmarkClass
        {
            public bool SelectArray(string[] array, string soughtStr)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == soughtStr)
                        return true;
                }
                return false;
            }

            public bool SelectHash(HashSet<Str> hashSetStr, Str soughtStrHash)
            {
                if (hashSetStr.Contains(soughtStrHash))
                {
                    return true;
                }
                return false;
            }

            public (string[], HashSet<Str>) TestTest()
            {
                Random random = new Random();
                int countStr = 10000;
                int lengthStr = 20;
                string[] arrayStr = new string[countStr];
                var hashSet = new HashSet<Str>();

                for (int i = 0; i < countStr; i++)
                {
                    string tStr = null;
                    for (int j = 0; j < lengthStr; j++)
                    {
                        tStr += Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))).ToString();
                    }
                    arrayStr[i] = tStr;
                    var str = new Str() { RndString = tStr };
                    hashSet.Add(str);
                }
                return (arrayStr, hashSet);
            }

            [Benchmark]
            public void SelectArray()
            {
                var (arrayStr, hashSet) = TestTest();
                for (int i = 0; i < 1; i++)
                {
                    SelectArray(arrayStr, arrayStr[i*900]);
                }
            }

            [Benchmark]
            public void SelectHash()
            {
                var (arrayStr, hashSet) = TestTest();
                for (int i = 0; i < 1; i++)
                {
                    var str = new Str() { RndString = arrayStr[i*900] };
                    SelectHash(hashSet, str);
                }
            }
        }

    }