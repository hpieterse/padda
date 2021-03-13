using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Handsaw.Padda.Engine.Services
{
  internal class InteropLoadService : IInteropLoadService
  {
    private readonly Lazy<Task<IJSObjectReference>> _importModuleTask;
    private readonly IJSUnmarshalledRuntime _jsUnmarshalledRuntime;

    public InteropLoadService(IJSRuntime jsRuntime, IJSUnmarshalledRuntime jsUnmarshalledRuntime)
    {
      _jsUnmarshalledRuntime = jsUnmarshalledRuntime;
      _importModuleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
       "import", $"./_content/Handsaw.Padda.Engine/unmarshalledImportInterop.js").AsTask());
    }

    public async Task<IJSUnmarshalledObjectReference> LoadUnmarshalled(string jsFileName)
    {
      var importModule = await _importModuleTask.Value;

      var importId = await importModule.InvokeAsync<string>("unmarshalledImport", $"../../{jsFileName}");

      var module = _jsUnmarshalledRuntime
        .InvokeUnmarshalled<string, IJSUnmarshalledObjectReference>(
          "getUnmarshalledModule",
          importId);

      return module;
    }
  }
}
