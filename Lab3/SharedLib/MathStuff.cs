using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib
{
    [SpecialClass(2)]
    public static class MathStuff
    {
        public static double CircleCircumference(double diameter)
        {
            return (Math.PI * diameter);
        }

        public static double CircleArea(double diameter)
        {
            return Math.Pow((diameter / 2), 2) * Math.PI;
        }

        public static double RectangleArea(double length, double width)
        {
            return length * width;
        }
    }
}
