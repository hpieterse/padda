using System.Collections.Generic;

namespace Handsaw.Padda.Models
{
  internal class InternalGameState
  {
    private long _msSinceLastGameTimeDecrease = 0;

    public bool GameStarted { get; private set; } = false;

    public long TotalGameTimeElapsed { get; private set; } = 0;

    public int GameTimeLeftSeconds { get; private set; } = 60;

    public long MsSinceGameOver { get; private set; }

    public int Score { get; private set; }

    public int HighScore { get; set; }

    public IEnumerable<HighScore> HighScores { get; set; }

    public void Reset()
    {
      GameStarted = false;
      Score = 0;
      _msSinceLastGameTimeDecrease = 0;
      TotalGameTimeElapsed = 0;
      GameTimeLeftSeconds = 60;
      MsSinceGameOver = 0;
    }

    public void Start()
    {
      Reset();
      GameStarted = true;
    }

    public void AddScore(int toAdd)
    {
      Score += toAdd;
      if(Score > HighScore)
      {
        HighScore = Score;
      }

      // 2 seconds per point;
      var newGameTimeLeft = GameTimeLeftSeconds + toAdd * 2;
 
      if (newGameTimeLeft > 99)
      {
        newGameTimeLeft = 99;
      }
      GameTimeLeftSeconds = newGameTimeLeft;
    }


    public void AddElapsedtime(long msElapsed)
    {
      if (!GameStarted)
      {
        return;
      }
      TotalGameTimeElapsed += msElapsed;
      _msSinceLastGameTimeDecrease += msElapsed;
      if (GameTimeLeftSeconds == 0)
      {
        MsSinceGameOver += msElapsed;
      }

      if (_msSinceLastGameTimeDecrease > 1000)
      {
        var secondsToSubtract = (int)(_msSinceLastGameTimeDecrease / 1000);
        GameTimeLeftSeconds -= secondsToSubtract;
        if (GameTimeLeftSeconds < 0)
        {
          GameTimeLeftSeconds = 0;
         
        }

        _msSinceLastGameTimeDecrease = (_msSinceLastGameTimeDecrease % 1000);
      }
    }
  }
}
