using System.Drawing;
using Handsaw.Padda.Engine.Components;
using Handsaw.Padda.Engine.Extensions;

namespace Handsaw.Padda.Engine.Models
{
  /// <summary>
  /// A line on the canvas
  /// </summary>
  public abstract class CanvasLine : CanvasObject
  {
    /// <summary>
    /// The end of the line, as a factor of the width of the canvas
    /// </summary>
    public PointF LineEnd { get; set; }

    /// <summary>
    /// The color of the line
    /// </summary>
    public Color Color { get; set; } = Color.FromKnownColor(KnownColor.Black);

    /// <summary>
    /// Width of the line, as a factor of the canvas width
    /// </summary>
    public float LineWidth { get; set; } = 1f;

    /// <inheritdoc/>
    public override  void QueRender(Canvas canvas)
    {
      canvas.QueDrawLine(Position, LineEnd, Color, LineWidth);
    }

    /// <inheritdoc/>
    public override bool Contains(PointF point)
    {
      var distanceFromStart = Position.DistanceTo(point);
      var distanceToEnd = point.DistanceTo(LineEnd);
      var totalDistance = Position.DistanceTo(LineEnd);
      return distanceFromStart + distanceToEnd - totalDistance < 0.01;
    }
  }
}