
using Handsaw.Padda.Engine.Models;
using System.Drawing;
using Handsaw.Padda.Engine.Extensions;
using Handsaw.Padda.Shared;

namespace Handsaw.Padda.Models.CanvasObjects
{
  public class Score : CanvasText
  {
    public override void Spawn(float aspectRatio)
    {
      base.Spawn(aspectRatio);
      FontSize = 0.08f;
      Font = FontConstants.FontName;

      var relativeFontWidth = FontConstants.FontWidth * FontSize;
      var relativeFontHeight = FontConstants.FontHeight * FontSize;

      Position = new PointF(
        relativeFontWidth * 2,
        (1f - relativeFontWidth * 2).CovertYtoRelativeY(aspectRatio) - relativeFontHeight
      );
    }
  }
}
