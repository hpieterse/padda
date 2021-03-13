using System.Drawing;
using Handsaw.Padda.Engine.Components;

namespace Handsaw.Padda.Engine.Models
{
  /// <summary>
  /// A square sprite on the canvas
  /// </summary>
  public abstract class CanvasSquare : CanvasObject
  {
    /// <summary>
    /// The size as a factor of the canvas width
    /// </summary>
    public SizeF Size { get; set; }

    /// <summary>
    /// The color of the square
    /// </summary>
    public Color Color { get; set; } = Color.FromKnownColor(KnownColor.Black);

    /// <summary>
    /// The factor which the touch target is larger tan the actual size of the
    /// sprite
    /// </summary>
    public float TouchTargetSize { get; set; } = 1f;

    /// <inheritdoc/>
    public override void QueRender(Canvas canvas)
    {
      canvas.QueDrawRect(Position, Size, Color);
    }

    /// <inheritdoc/>
    public override bool Contains(PointF point)
    {
      var touchTargetBottomLeftX = Position.X - Size.Width * (TouchTargetSize - 1);
      var touchTargetBottomLeftY = Position.Y - Size.Height * (TouchTargetSize - 1);

      var positionTopRightX = (Position.X + Size.Width);
      var positionTopRightY = (Position.Y + Size.Height);
      var touchTargetTopRightX = positionTopRightX + Size.Width * (TouchTargetSize - 1);
      var touchTargetTopRightY = positionTopRightY + Size.Height * (TouchTargetSize - 1);

      return touchTargetBottomLeftX < point.X
          && touchTargetBottomLeftY < point.Y
          && touchTargetTopRightX > point.X
          && touchTargetTopRightY > point.Y;
    }

  }
}