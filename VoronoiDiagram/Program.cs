using System;
using System.Drawing;

namespace VoronoiDiagram
{
    class Program
    {

        static void Main(string[] args)
        {
            int numberOfPoints = 10;
            Size size = new Size(512, 512);

            #region Dump parameters
            Console.WriteLine("Generate Voronoi Diagram");
            Console.WriteLine("Number of points: {0}", numberOfPoints);
            Console.WriteLine("Bitmap size: [{0},{1}]", size.Width, size.Height);
            #endregion

            var bitmap = VoronoiDiagram.Generate(numberOfPoints, size, Distance.EuclideanDistance);

            #region Save result as bitmap
            bitmap.Save(@"voronoi.bmp");
            #endregion
        }


    }
}
