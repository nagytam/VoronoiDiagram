using System;
using System.Drawing;

namespace VoronoiDiagram
{
    public static class Distance
    {
        public delegate double GetDistance(Point p1, Point p2);

        public static double EuclideanDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow((p2.X - p1.X), 2) + Math.Pow((p2.Y - p1.Y), 2));
        }

    }
}
