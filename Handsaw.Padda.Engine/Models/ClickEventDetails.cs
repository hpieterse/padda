using System.Collections.Generic;
using System.Drawing;

namespace Handsaw.Padda.Engine.Models
{
  /// <summary>
  /// Details of a click event on the canvas
  /// </summary>
  public class ClickEventDetails
  {
    /// <summary>
    /// Location of the click. Factor of the canvas width
    /// </summary>
    public PointF Location { get; set; }

    /// <summary>
    /// The objects that where clicked on
    /// </summary>
    public IEnumerable<CanvasObject> ClickedObjects { get; set; }
  }
}
