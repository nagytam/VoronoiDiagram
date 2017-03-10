using System;
using System.Collections.Generic;
using System.Drawing;

namespace VoronoiDiagram
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            int numberOfPoints = 10;
            int width = 512;
            int height = 512;

            Console.WriteLine("Generate Voronoi Diagram");
            Console.WriteLine("Number of points: {0}", numberOfPoints);
            Console.WriteLine("Bitmap size: [{0},{1}]", width, height);

            var points = CreatePoints(rnd, numberOfPoints, width, height);
            var colors = CreateCellColorMap(numberOfPoints);
            var bitmap = new Bitmap(width, height);

            bitmap.Fill(Color.White);

            SetCellCenters(bitmap, points);
            CreateCell(bitmap, points, colors);
            SetCellCenters(bitmap, points);

            bitmap.Save(@"c:\temp\voronoi.bmp");
        }

        private static List<Point> CreatePoints(Random rnd, int numberOfPoints, int width, int height)
        {
            var points = new List<Point>();
            for (int i = 0; i < numberOfPoints; i++)
            {
                points.Add(new Point() { X = (int)(rnd.NextDouble() * width), Y = (int)(rnd.NextDouble() * height) });
            }
            return points;
        }

        private static List<Color> CreateCellColorMap(int numberOfPoints)
        {
            var colors = new List<Color>();
            for (int i = 0; i < numberOfPoints; i++)
            {
                colors.Add(
                    Color.FromArgb(255,
                        (int)(rnd.NextDouble() * 200 + 50),
                        (int)(rnd.NextDouble() * 200 + 55),
                        (int)(rnd.NextDouble() % 200 + 50)));
            }
            return colors;
        }

        private static void SetCellCenters(Bitmap bitmap, List<Point> points)
        {
            foreach (var point in points)
            {
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        bitmap.SetPixel(point.X + i, point.Y + j, Color.Black);
                    }
                }
            }
        }

        private static void CreateCell(Bitmap bitmap, List<Point> points, List<Color> colors)
        {
            for (int hh = 0; hh < bitmap.Height; hh++)
            {
                for (int ww = 0; ww < bitmap.Width; ww++)
                {
                    int ind = -1;
                    double dist = int.MaxValue;
                    for (int it = 0; it < points.Count; it++)
                    {
                        var p = points[it];
                        var d = GetDistance(p, new Point(ww, hh));
                        if (d < dist)
                        {
                            dist = d;
                            ind = it;
                        }
                    }

                    if (ind > 0)
                    {
                        bitmap.SetPixel(ww, hh, colors[ind]);
                    }
                }
            }
        }

        private static double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow((p2.X - p1.X), 2) + Math.Pow((p2.Y - p1.Y), 2));
        }
    }
}
