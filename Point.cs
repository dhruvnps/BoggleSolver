using System;
using System.Collections.Generic;
using System.Linq;

namespace BoggleSolver
{
    public class Point
    {
        public readonly int row, col;

        public Point(int row, int col)
        {
            this.row = row;
            this.col = col;
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