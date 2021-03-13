
using System;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Handsaw.Padda.Engine.Extensions
{
  /// <summary>
  /// Extensions realted to drawing
  /// </summary>
  internal static class DrawingExtensions
  {

    /// <summary>
    /// Color to Hex Code
    /// </summary>
    /// <param name="color">The color to convert</param>
    /// <returns>A hex string that can be used in HTML, JS and CSS</returns>
    public static string ToHexCode(this Color color)
    {
      return ColorTranslator.ToHtml(Color.FromArgb(color.ToArgb()));
    }

    /// <summary>
    /// Trim a string to a specific lenght in bytes
    /// </summary>
    /// <param name="input">The string to trim</param>
    /// <param name="maxLength">Number of bytes the string can take</param>
    /// <returns>The trimmed string</returns>
    public static string TrimToByteLength(this string input, int maxLength)
    {
      return new string(input
          .TakeWhile((c, i) =>
              Encoding.UTF8.GetByteCount(input.Substring(0, i + 1)) <= maxLength)
          .ToArray());
    }

    /// <summary>
    /// The distance between two points
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public static float DistanceTo(this PointF start, PointF end)
    {
      var dX = end.X - start.X;
      var dy = end.Y - start.Y;
      return (float)Math.Sqrt((dX * dX) + (dy * dy));
    }
  }
}
