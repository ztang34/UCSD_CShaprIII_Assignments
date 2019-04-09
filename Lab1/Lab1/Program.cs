using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        
        static PointList points = new PointList(); //initiate Point List
        static void Main(string[] args)
        {
            #region Events

            Console.WriteLine("Part 1: Events and delegates: ");
            points.Changed += delegate (object sender, PointListChangedEventArgs e)
            {
                Console.WriteLine($"Points changed: {e.Operation}");
            };

            points.Add(new Point(-4, -7));
            points.Add(new Point(0, 0));
            points.Add(new Point(1, 2));
            points.Add(new Point(-4, 5));
            points.Insert(2, new Point(3, 1));
            points.Add(new Point(7, -2));
            points[0] = new Point(2, 1);
            points.RemoveAt(2);
            #endregion Events

            #region Functional Programming

            Console.WriteLine(new string('=', 40));
            Console.WriteLine("Part 2: Functional programming");
            //check orgin
            Func<Point, bool> checkOrgin = (Point p) => p.X == 0 && p.Y == 0;
            if(points.Any(checkOrgin))
            {
                Console.WriteLine("There is at least one point at the orgin in this list");
            }
            else
            {
                Console.WriteLine("There is no point at the orgin in this list");
            }
            Console.WriteLine();

            //find all first quadrant points
            Func<Point, bool> checkFirstQuadrant = (Point p) => p.X > 0 && p.Y > 0;
            Console.WriteLine("Points in first quadrant: ");
            foreach(Point p in points.Where(checkFirstQuadrant))
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            //calculate "sum" of all coordinates (coordinate is transformed into integer as x + y
            Func<Point, int> coordinateSum = (Point p) => p.X + p.Y;
            Console.WriteLine($"The sum of all points in this list is {points.Sum(coordinateSum)}");
            Console.WriteLine();

            #endregion Functional Programming
            Console.WriteLine(new string('=', 40));
            Console.WriteLine("Press <ENTER> to quit...");
            Console.ReadLine();
        }
        

    }
}
