namespace Handsaw.Padda.Engine.Extensions
{
  /// <summary>
  /// Extensions used to make working with size and distanced easier
  /// </summary>
  public static class SizeExtensions
  {
    /// <summary>
    /// Convert a Y factor (fraction of the canvas height) to a X factor
    /// </summary>
    /// <param name="y">The y size as a factor of the height of the canvas</param>
    /// <param name="aspectRatio">The aspect ratio of the canvas</param>
    /// <returns></returns>
    public static float CovertYtoRelativeY(this float y,  float aspectRatio)
    {
      return y / aspectRatio;
    }

    /// <summary>
    /// Convert a Y factor (fraction of the canvas height) to a X factor
    /// </summary>
    /// <param name="y">The y size as a factor of the height of the canvas</param>
    /// <param name="aspectRatio">The aspect ratio of the canvas</param>
    /// <returns></returns>
    public static float CovertYtoRelativeY(this double y, float aspectRatio)
    {
      return ((float)y).CovertYtoRelativeY(aspectRatio);
    }

    /// <summary>
    /// Convert a width relative Y factor (fraction of the canvas width) to a
    /// Y factor (faction of the canvas height)
    /// </summary>
    /// <param name="y">The y size as a factor of the width of the canvas</param>
    /// <param name="aspectRatio">The aspect ratio of the canvas</param>
    /// <returns></returns>
    public static float CovertRelativeYToY(this float y, float aspectRatio)
    {
      return y * aspectRatio;
    }
  }
}
