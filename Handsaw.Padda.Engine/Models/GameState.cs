using System.Collections.Generic;

namespace Handsaw.Padda.Engine.Models
{
  /// <summary>
  /// The current state of the Game
  /// </summary>
  public class GameState
  {

    private List<CanvasObject> _sprites = new List<CanvasObject>();

    private List<CanvasObject> _newSprites  = new List<CanvasObject>();

    /// <summary>
    /// The objects to draw on the canvas
    /// </summary>
    public IEnumerable<CanvasObject> Sprites { get { return _sprites;} }


    /// <summary>
    /// Add an object to the Game State
    /// </summary>
    /// <param name="canvasObject"></param>
    public void AddObject(CanvasObject canvasObject){
      canvasObject.OnRemove += () => {
        _newSprites.Remove(canvasObject);
      };
      _sprites.Add(canvasObject);
      _newSprites.Add(canvasObject);
    }

    /// <summary>
    /// Clear all objects from th game state
    /// </summary>
    public void ClearObjects()
    {
      _newSprites.Clear();
      _sprites.Clear();
    }

    internal void Update(){
      _sprites.Clear();
      _sprites.AddRange(_newSprites);
    }
  }
}
