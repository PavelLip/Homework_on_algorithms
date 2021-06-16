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
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            Console.ReadLine();
        }

    }

    public class BechmarkClass
    {
        static Random rand = new Random();
        PointClass test11 = new PointClass { X = (float)rand.NextDouble(), Y = (float)rand.NextDouble() };
        PointClass test12 = new PointClass { X = (float)rand.NextDouble(), Y = (float)rand.NextDouble() };
        PointStructFloat test21 = new PointStructFloat { X = (float)rand.NextDouble(), Y = (float)rand.NextDouble() };
        PointStructFloat test22 = new PointStructFloat { X = (float)rand.NextDouble(), Y = (float)rand.NextDouble() };
        PointStructDouble test31 = new PointStructDouble { X = rand.NextDouble(), Y = rand.NextDouble() };
        PointStructDouble test32 = new PointStructDouble { X = rand.NextDouble(), Y = rand.NextDouble() };
        PointStructFloat test41 = new PointStructFloat { X = (float)rand.NextDouble(), Y = (float)rand.NextDouble() };
        PointStructFloat test42 = new PointStructFloat { X = (float)rand.NextDouble(), Y = (float)rand.NextDouble() };

        public class PointClass
        {
            public float X { get; set; }
            public float Y { get; set; }
        }

        public struct PointStructFloat
        {
            public float X { get; set; }
            public float Y { get; set; }
        }
        public struct PointStructDouble
        {
            public double X { get; set; }
            public double Y { get; set; }
        }

        public float PointDistanceClass(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (float)Math.Sqrt((x * x) + (y * y));
        }

        public float PointDistanceStructFloat(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (float)Math.Sqrt((x * x) + (y * y));
        }
        public double PointDistanceStructDouble(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        public float PointDistanceStructFloatNoSqrt(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        [Benchmark]
        public void TestDistanceReferenceType()
        {
            PointDistanceClass(test11, test12);
        }
        [Benchmark]
        public void TestDistanceSignificantFloat()
        {
            PointDistanceStructFloat(test21, test22);
        }
        [Benchmark]
        public void TestDistanceSignificantDouble()
        {
            PointDistanceStructDouble(test31, test32);
        }
        [Benchmark]
        public void TestDistanceSignificantFloatNoSqrt()
        {
            PointDistanceStructFloatNoSqrt(test41, test42);
        }
    }
}

