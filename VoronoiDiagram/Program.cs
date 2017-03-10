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

            #region Dump parameters
            Console.WriteLine("Generate Voronoi Diagram");
            Console.WriteLine("Number of points: {0}", numberOfPoints);
            Console.WriteLine("Bitmap size: [{0},{1}]", width, height);
            #endregion

            #region Generate Voronoi diagrams randomly
            var points = CellUtilities.CreatePoints(rnd, numberOfPoints, width, height);
            var colors = CellUtilities.CreateCellColorMap(rnd, numberOfPoints);
            var bitmap = new Bitmap(width, height);

            bitmap.Fill(Color.White);

            CellUtilities.SetCellCenters(bitmap, points);
            CellUtilities.CreateCell(bitmap, points, colors);
            CellUtilities.SetCellCenters(bitmap, points);
            #endregion

            #region Save result as bitmap
            bitmap.Save(@"voronoi.bmp");
            #endregion
        }


    }
}
