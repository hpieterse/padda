using System.Collections.Generic;
using System.Threading.Tasks;
using Handsaw.Padda.Models;

namespace Handsaw.Padda.Services
{
  public interface IStorageService
  {
    Task<IEnumerable<HighScore>> GetHighScores();

    Task<IEnumerable<HighScore>> AddHighScore(HighScore score);
  }
}
