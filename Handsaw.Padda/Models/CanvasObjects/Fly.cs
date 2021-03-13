using System;
using Handsaw.Padda.Engine.Models;
using System.Drawing;
using Handsaw.Padda.Engine.Extensions;

namespace Handsaw.Padda.Models.CanvasObjects
{
  public class Fly : CanvasSquare
  {
    /// <summary>
    /// factor of the width per second
    /// </summary>
    private float _speed { get; set; }

    /// <summary>
    /// Current angle of travel in radians
    /// </summary>
    private float _angle { get; set; }

    /// <summary>
    /// Radians per second
    /// </summary>
    private float _turningSpeed { get; set; }

    private long _millisecondsSiniceLastDirectionChange;

    private readonly Random _random = new Random();

    private readonly long _createdTime;

    public Fly(long totalGameTimeElapsed)
    {
      _createdTime = totalGameTimeElapsed;
    }

    public override void Spawn(float aspectRatio)
    {
      base.Spawn(aspectRatio);

      Size = new SizeF(0.01f, 0.01f);
      Color = Color.FromKnownColor(KnownColor.Black);
      TouchTargetSize = 2f;

      var randomX = _random.NextDouble();
      var randomY = (Size.Height / 2 + (1 - _random.NextDouble() * 0.5)).CovertYtoRelativeY(aspectRatio);

      var spawnLocation = _random.Next(1, 5);
      switch (spawnLocation)
      {
        case 1:
          Position = new PointF(-Size.Width, (float)randomY);
          break;
        case 3:
        case 2:
          Position = new PointF((float)randomX, (1 + Size.Height).CovertYtoRelativeY(aspectRatio));
          break;
        case 4:
        default:
          Position = new PointF(1 + Size.Width, (float)randomY);
          break;
      }

      // between 0.1%  and 0.7% per second
      var speedMax = 0.3f;
      var speedMin = 0.01f;

      // 0.1 per 100s
      speedMax += _createdTime / (10f * 100f * 1000f);
      if(speedMax > 2f)
      {
        speedMax = 2f;
      }

      // 0.1 per 30s
      speedMin += _createdTime / (100f * 30f * 1000f);

      if(speedMin > speedMax)
      {
        speedMin = speedMax;
      }

      _speed = (float)_random.NextDouble() * (speedMax - speedMin) + speedMin;

      // start angled to center
      var dX = 0.5f - Position.X;
      var dy = 0.5.CovertYtoRelativeY(aspectRatio) - Position.Y;
      _angle = (float)Math.Atan2(dy, dX);

      _millisecondsSiniceLastDirectionChange = 0;
    }

    public override void Update(long ticksSinceLastUpdate, float aspectRatio)
    {
      
      base.Update(ticksSinceLastUpdate, aspectRatio);
      _millisecondsSiniceLastDirectionChange += ticksSinceLastUpdate;


      var distanceCoveredSinceLastDirectionChange = (_millisecondsSiniceLastDirectionChange /  1000f) * _speed;

      // increasing chance of direction change as distance increases
      var shouldChangeAngle = (_random.NextDouble() + distanceCoveredSinceLastDirectionChange) > 0.8;
      if (shouldChangeAngle)
      {
        var distanceTravelled = Lifespan * _speed / 1000f;

        var maxAngle = Math.PI * 8f;
        // at 0,5 distance travelled, max turning angle allowed
        if(distanceTravelled < 0.5f)
        {
          maxAngle = Math.PI * 8 * (distanceTravelled / 0.5f);
        }

        // get random direction change
        // between -720deg and 720deg per second
        _turningSpeed = (float)(_random.NextDouble() * maxAngle - maxAngle/2);
       
        _millisecondsSiniceLastDirectionChange = 0;
      }

      var delta = _turningSpeed / 1000f * ticksSinceLastUpdate;
      _angle -= (float)delta;
    
      var distanceToMove = _speed * (ticksSinceLastUpdate / 1000f);

       var newX = Position.X + distanceToMove * (float)Math.Cos(_angle);
       var newY = Position.Y + distanceToMove * (float)Math.Sin(_angle);

       Position = new PointF(newX, newY);

       if (Position.X + Size.Width < -0.1
       || Position.X - Size.Width > 1.1
       || (Position.Y + Size.Height).CovertRelativeYToY(aspectRatio) < -0.1
       || (Position.Y - Size.Height).CovertRelativeYToY(aspectRatio) > 1.1)
       {
         Remove();
       }
    }
  }
}