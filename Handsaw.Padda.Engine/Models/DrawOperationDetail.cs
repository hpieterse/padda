
using System.Drawing;

namespace Handsaw.Padda.Engine.Models
{
  internal class DrawOperationDetail
  {
    public DrawOperation DrawOperation { get; set; }

    public DrawOperationDetail(PointF position, float radius, float startAngle, float endAngle, bool clockwise, string color)
    {
      DrawOperation = DrawOperation.Arch;
      X = position.X;
      Y = position.Y;
      Radius = radius;
      StartAngle = startAngle;
      EndAngle = endAngle;
      Clockwise = clockwise;
      Color = color;
    }

    public DrawOperationDetail(PointF position, SizeF size, string color)
    {
      DrawOperation = DrawOperation.Rectangle;
      X = position.X;
      Y = position.Y;
      Width = size.Width;
      Height = size.Height;
      Color = color;
    }

    public DrawOperationDetail(PointF start, PointF end, float width, string color)
    {
      DrawOperation = DrawOperation.Line;
      X = start.X;
      Y = start.Y;
      Width = end.X;
      Height = end.Y;
      Radius = width;
      Color = color;
    }

    public DrawOperationDetail(PointF start, string font, string text, string color)
    {
      DrawOperation = DrawOperation.Text;
      X = start.X;
      Y = start.Y;
      Content = text;
      Color = color;
      Font = font;
    }

    public DrawOperationDetail(string imageId, PointF position, SizeF size, Point slicePosition, Size sliceSize)
    {
      DrawOperation = DrawOperation.Image;
      Content = imageId;
      X = position.X;
      Y = position.Y;
      Width = size.Width;
      Height = size.Height;
      X2 = slicePosition.X;
      Y2 = slicePosition.Y;
      Width2 = sliceSize.Width;
      Height2 = sliceSize.Height;
    }

    public float X { get; private  set; }
    public float Y { get; private set; }
    public float Width { get; private set; }
    public float Height { get; private  set; }
    public float X2 { get; private set; }
    public float Y2 { get; private set; }
    public float Width2 { get; private set; }
    public float Height2 { get; private set; }
    public float Radius { get; private set; }
    public float StartAngle { get; private  set; }
    public float EndAngle { get; private   set; }
    public bool Clockwise { get; private set; }
    public string Content { get; private set; }
    public string Color { get; set; }
    public string Font { get; set; }

  }
}
