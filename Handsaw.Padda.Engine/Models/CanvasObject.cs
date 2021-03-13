using System;
using System.Drawing;
using System.Threading.Tasks;
using Handsaw.Padda.Engine.Components;

namespace Handsaw.Padda.Engine.Models
{
  /// <summary>
  /// A object on the canvas
  /// </summary>
  public abstract class CanvasObject
  {

    /// <summary>
    /// Position as a factor of the canvas width. X starts on the left, Y
    /// starts on the bottom.
    /// </summary>
    public PointF Position { get; set; }

    /// <summary>
    /// Implement logic to update since last render
    /// </summary>
    /// <param name="millisecondsElapsed"></param>
    /// <param name="aspectRatio"></param>
    /// <returns></returns>
    public virtual void Update(long millisecondsElapsed, float aspectRatio)
    {
      Lifespan += millisecondsElapsed;
    }

    /// <summary>
    /// Set the initial values right before the first time the sprite is drawn
    /// </summary>
    /// <param name="aspectRatio"></param>
    /// <returns></returns>
    public virtual void Spawn(float aspectRatio)
    {
      Lifespan = 0;
      Spawned = true;
    }

    /// <summary>
    /// Event triggered when the object is removed from the canvas
    /// </summary>
    internal event Action OnRemove;

    /// <summary>
    /// Indicates if the object has been spawned
    /// </summary>
    public bool Spawned { get; internal set; }

    /// <summary>
    /// Total time alive in ms
    /// </summary>
    public float Lifespan { get; internal set; } = 0;

    /// <summary>
    /// Render logic
    /// </summary>
    /// <param name="canvas"></param>
    /// <returns></returns>
    public abstract void QueRender(Canvas canvas);

    /// <summary>
    /// Indicates if the object has been loaded
    /// </summary>
    public bool Loaded { get; internal set; }

    /// <summary>
    /// Load any resources necessary to render the object. Called before
    /// Spawn
    /// </summary>
    /// <param name="canvas"></param>
    public virtual Task Load(Canvas canvas)
    {
      Loaded = true;
      return Task.FromResult<object>(null);
    }

    /// <summary>
    /// Check whether object contains a point. Used for collision detection
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    public abstract bool Contains(PointF point);

    /// <summary>
    /// Remove the object from the game state
    /// </summary>
    public void Remove()
    {
      Spawned = false;
      OnRemove?.Invoke();
    }
  }
}
