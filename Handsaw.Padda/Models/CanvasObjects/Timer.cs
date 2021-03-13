using System.Drawing;
using Handsaw.Padda.Engine.Extensions;
using Handsaw.Padda.Engine.Models;
using Handsaw.Padda.Shared;

namespace Handsaw.Padda.Models.CanvasObjects
{
  public class Timer : CanvasText
  {
    public override void Spawn(float aspectRatio)
    {
      base.Spawn(aspectRatio);
      FontSize = 0.09f;
      Font = FontConstants.FontName;
      var relativeFontWidth = FontConstants.FontWidth * FontSize;
      var relativeFontHeight = FontConstants.FontHeight * FontSize;

      var scoreRelativeFontWidth = FontConstants.FontWidth * 0.08f;
      var scoreRelativeFontHeight = FontConstants.FontHeight * 0.08f;
      var heightDifference = scoreRelativeFontHeight - relativeFontHeight;

      Position = new PointF(
        0.5f - relativeFontWidth,
        (1f - scoreRelativeFontWidth * 2).CovertYtoRelativeY(aspectRatio) - relativeFontHeight - heightDifference/2
      );
    }
  }
}
