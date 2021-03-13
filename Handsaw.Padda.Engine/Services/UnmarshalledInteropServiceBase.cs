using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Handsaw.Padda.Engine.Services
{
  /// <summary>
  /// Base class for interop services
  /// </summary>
  internal class UnmarshalledInteropServiceBase : IAsyncDisposable
  {
    private readonly IInteropLoadService _loadService;

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="loadService">Load service</param>
    /// <param name="jsFileName">Relative path to th JS file</param>
    public UnmarshalledInteropServiceBase(IInteropLoadService loadService, string jsFileName)
    {
      _loadService = loadService;
      Module = new(() => _loadService.LoadUnmarshalled(jsFileName));

      Task.Factory.StartNew(() => OnInitialized());
    }

    /// <summary>
    /// The JS module
    /// </summary>
    public Lazy<Task<IJSUnmarshalledObjectReference>> Module { get; private set; }

    /// <summary>
    /// Lifecycle event called when the js file has been loaded
    /// </summary>
    /// <returns></returns>
    public virtual Task OnInitialized()
    {
      return Task.FromResult<object>(null);
    }

    /// <summary>
    /// Upload the JS file
    /// </summary>
    /// <returns></returns>
    public async ValueTask DisposeAsync()
    {
      if (Module.IsValueCreated)
      {
        var module = await Module.Value;
        await module.DisposeAsync();
      }
    }
  }
}