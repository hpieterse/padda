using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Handsaw.Padda.Engine.Services
{
  internal class AudioService : UnmarshalledInteropServiceBase, IAudioService
  {
    public AudioService(IInteropLoadService loadService) : base(loadService, "_content/Handsaw.Padda.Engine/audioInterop.js")
    {
    }

    public async Task<IEnumerable<Guid>> LoadAudio(params string[] sources)
    {
      var module = await Module.Value;
      var serviceReference = DotNetObjectReference.Create(this);
      var tasks = sources.Select(async (src) => {
        var audioId = Guid.NewGuid();
        await module.InvokeVoidAsync("loadAudio", src, audioId);
        return audioId;
      });

      var result = await Task.WhenAll(tasks.ToArray());

      return result;
    }

    public async Task UnloadAudio(Guid id)
    {
      var module = await Module.Value;
      await module.InvokeVoidAsync("unloadAudio", id);
    }

    public async Task PlayAudio(Guid id, bool loop = false, float startOffset = 0, float? playLength = null)
    {
      var module = await Module.Value;
      await module.InvokeVoidAsync("playAudio", id, loop, startOffset, playLength);
    }

    public async Task StopAudio(Guid id)
    {
      var module = await Module.Value;
      await module.InvokeVoidAsync("stopAudio", id);
    }
  }
}
