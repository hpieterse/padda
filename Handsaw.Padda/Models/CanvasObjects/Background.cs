using System.Drawing;
using Handsaw.Padda.Engine.Models;
using Handsaw.Padda.Engine.Extensions;

namespace Handsaw.Padda.Models.CanvasObjects
{
  public class Background : CanvasImage
  {
    public Background() : base("./images/Background.png", new Size(320, 569))
    {
    }

    public override void Spawn(float aspectRatio)
    {
      base.Spawn(aspectRatio);
      Position = new PointF(0f,0f.CovertYtoRelativeY(aspectRatio));
      Size = new SizeF(1f, 1f.CovertYtoRelativeY(aspectRatio));
    }
  }
}
