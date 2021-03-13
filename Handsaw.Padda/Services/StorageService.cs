using System.Threading.Tasks;
using Handsaw.Padda.Models;
using Blazored.LocalStorage;
using System.Linq;
using System.Collections.Generic;

namespace Handsaw.Padda.Services
{
  public class StorageService : IStorageService
  {
    private readonly ILocalStorageService _localStorage;
    private readonly string _highScoreKey = "highscores";
    public StorageService(ILocalStorageService localStorage)
    {
      _localStorage = localStorage;
    }

    public async Task<IEnumerable<HighScore>> AddHighScore(HighScore score)
    {
      var highScores = await _localStorage.GetItemAsync<HighScore[]>(_highScoreKey);

      var newHighScores = highScores
       .Union(new[] { score })
       .OrderByDescending(c => c.Score)
       .Take(highScores.Count());

      await _localStorage.SetItemAsync(_highScoreKey, newHighScores.ToArray());

      return newHighScores;
    }

    public async Task<IEnumerable<HighScore>> GetHighScores()
    {
      var highScores = await _localStorage.GetItemAsync<HighScore[]>(_highScoreKey);

      if (highScores == null)
      {
        var newHighScores = new List<HighScore>();
        for (int i = 0; i < 10; i++)
        {
          newHighScores.Add(new HighScore {
            Name = "AAA",
            Score = 0,
          });
        }

        highScores = newHighScores.ToArray();
        await _localStorage.SetItemAsync(_highScoreKey, highScores);
      }
      return highScores;
    }
  }
}
