using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Algorithms_and_data_structures
{
    class PointStruct
    {
        public float x { get; set; }
        public float y { get; set; }


        public float PointDistanceClass(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.x - pointTwo.x;
            float y = pointOne.y - pointTwo.y;
            return (float)Math.Sqrt((x * x) + (y * y));
        }

    }

    class PointStructDouble
    {
        public double x { get; set; }
        public double y { get; set; }

        public double PointDistanceClass(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.x - pointTwo.x;
            double y = pointOne.y - pointTwo.y;
            return Math.Sqrt((x * x) + (y * y));
        }
    }



}
