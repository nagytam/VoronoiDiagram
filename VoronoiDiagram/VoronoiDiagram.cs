using System;
using System.Drawing;

namespace VoronoiDiagram
{
    public static class VoronoiDiagram
    {

        public static Bitmap Generate(int numberOfPoints, Size size, Distance.GetDistance distance)
        {
            Random rnd = new Random(19761016);

            #region Generate Voronoi diagrams randomly
            var points = CellUtilities.CreatePoints(rnd, numberOfPoints, size);
            var colors = CellUtilities.CreateCellColorMap(rnd, numberOfPoints);
            var bitmap = new Bitmap(size.Width, size.Height);

            bitmap.Fill(Color.White);

            CellUtilities.SetCellCenters(bitmap, points);
            CellUtilities.CreateCell(bitmap, points, colors, distance);
            CellUtilities.SetCellCenters(bitmap, points);
            #endregion

            return bitmap;
        }
    }
}