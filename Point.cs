using System;
using System.Collections.Generic;
using System.Linq;

namespace BoggleSolver
{
    public class Point
    {
        public readonly int row;
        public readonly int col;

        public Point(int r, int c)
        {
            row = r;
            col = c;
        }

        public static void PrintPoints(List<Point> points)
        {
            foreach (Point point in points)
            {
                Console.Write("(" + point.row + ", ");
                Console.WriteLine(point.col + ")");
            }
        }
    }
}