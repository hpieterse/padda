using System.Drawing;
using Handsaw.Padda.Engine.Components;

namespace Handsaw.Padda.Engine.Models
{
  /// <summary>
  /// Text to render on the canvas
  /// </summary>
  public class CanvasText : CanvasObject
  {
    /// <summary>
    /// Font of the text
    /// </summary>
    public string Font { get; set; } = "Arial";

    /// <summary>
    /// Size of the font, as a factor of the canvas width
    /// </summary>
    public float FontSize { get; set; } = 0.05f;

    /// <summary>
    /// Text to render
    /// </summary>
    public string Text { get; set; } = "";

    /// <summary>
    /// Color of the text
    /// </summary>
    public Color Color { get; set; } = Color.FromKnownColor(KnownColor.Black);

    /// <inheritdoc/>
    public override bool Contains(PointF point)
    {
      return false;
    }

    /// <inheritdoc/>
    public override void QueRender(Canvas canvas)
    {
      canvas.QueDrawText(Position, Font, FontSize, Text, Color);
    }
  }
}
