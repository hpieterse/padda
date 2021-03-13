using Handsaw.Padda.Engine.Models;
using System.Drawing;

namespace Handsaw.Padda.Models.CanvasObjects
{
  public class Frog : CanvasImage
  {

    public Frog() : base("./images/Padda.png", new Size(64, 128))
    {

    }

    public override void Spawn(float aspectRatio)
    {
      base.Spawn(aspectRatio);

      Position = new PointF(0.4f, 0.15f);
      Size = new SizeF(0.2f, 0.2f);
      SlicePosition = new Point(0, 0);
      SliceSize = new Size(64, 64);
    }

    public void SetMouthOpen()
    {
      SlicePosition = new Point(0, 64);
    }

    public void SetMouthClosed()
    {
      SlicePosition = new Point(0, 0);
    }
  }
}
