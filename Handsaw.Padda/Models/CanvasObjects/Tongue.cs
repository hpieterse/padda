using System.Drawing;
using Handsaw.Padda.Engine.Models;

namespace Handsaw.Padda.Models.CanvasObjects
{
  public class Tongue : CanvasLine
  {

    public override void Spawn(float aspectRatio)
    {
      base.Spawn(aspectRatio);
      Color = ColorTranslator.FromHtml("#aa442b");
      LineWidth = 0.008f;
      Position = new PointF(0.5f, 0.24f);
    }

    public override void Update(long ticksSinceLastUpdate, float aspectRatio)
    {
      base.Update(ticksSinceLastUpdate, aspectRatio);

      if(Lifespan > 200)
      {
        Remove();
      }
    }
  }
}
