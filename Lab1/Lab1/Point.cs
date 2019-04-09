﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Point
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public Point (int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
