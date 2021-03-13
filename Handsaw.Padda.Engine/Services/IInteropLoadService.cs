using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Handsaw.Padda.Engine.Services
{
  /// <summary>
  /// Service that loads a js file
  /// </summary>
  public interface IInteropLoadService
  {
    /// <summary>
    /// Load a js file
    /// </summary>
    /// <param name="jsFileName">the relative path the js file</param>
    /// <returns></returns>
    Task<IJSUnmarshalledObjectReference> LoadUnmarshalled(string jsFileName);
  }
}
