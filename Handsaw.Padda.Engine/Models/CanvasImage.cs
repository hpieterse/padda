using System;
using System.Drawing;
using System.Threading.Tasks;
using Handsaw.Padda.Engine.Components;

namespace Handsaw.Padda.Engine.Models
{
  /// <summary>
  /// An image to draw on the canvas
  /// </summary>
  public class CanvasImage : CanvasObject
  {
    private Guid _imageId;

    /// <summary>
    /// Create an image object
    /// </summary>
    /// <param name="imageSource">Source of the image</param>
    /// <param name="originalSize">Size of the original image in pixels</param>
    public CanvasImage(string imageSource, Size originalSize)
    {
      ImageSource = imageSource;
      OriginalSize = originalSize;
    }

    /// <summary>
    /// Size of the image on the canvas as a factor of the width 
    /// </summary>
    public SizeF Size { get; set; }

    /// <summary>
    /// Original size of the image in pixels
    /// </summary>
    public Size OriginalSize { get; private set; }

    /// <summary>
    /// The row and column of the slice to show
    /// </summary>
    public Point? SlicePosition { get; set; }

    /// <summary>
    /// Size of a slice in pixels
    /// </summary>
    public Size? SliceSize { get; set; }

    /// <summary>
    /// The source path of the image
    /// </summary>
    public string ImageSource { get; private set; }

    /// <inheritdoc/>
    public override bool Contains(PointF point)
    {
      var touchTargetBottomLeftX = Position.X;
      var touchTargetBottomLeftY = Position.Y;

      var positionTopRightX = (Position.X + Size.Width);
      var positionTopRightY = (Position.Y + Size.Height);
      var touchTargetTopRightX = positionTopRightX;
      var touchTargetTopRightY = positionTopRightY;

      return touchTargetBottomLeftX < point.X
          && touchTargetBottomLeftY < point.Y
          && touchTargetTopRightX > point.X
          && touchTargetTopRightY > point.Y;
    }

    /// <inheritdoc/>
    public override async Task Load(Canvas canvas)
    {
      await base.Load(canvas);
      _imageId = await canvas.LoadImage(ImageSource);
    }

    /// <inheritdoc/>
    public override void QueRender(Canvas canvas)
    {
      canvas.QueDrawImage(_imageId, Position, Size, SlicePosition ?? new Point(0, 0), SliceSize ?? OriginalSize);
    }
  }
}
