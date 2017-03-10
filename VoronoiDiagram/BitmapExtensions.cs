using System.Drawing;

namespace VoronoiDiagram
{
    public static class BitmapExtensions
    {
        public static void Fill(this Bitmap bitmap, Color color)
        {
            using (Graphics gfx = Graphics.FromImage(bitmap))
            using (SolidBrush brush = new SolidBrush(color))
            {
                gfx.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);
            }
        }
    }
}
