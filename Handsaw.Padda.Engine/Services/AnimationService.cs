using System;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Handsaw.Padda.Engine.Services
{
  internal class AnimationService : UnmarshalledInteropServiceBase, IAnimationService
  {
    private Stopwatch _stopWatch;

    public AnimationService(IInteropLoadService loadService) : base(loadService, "_content/Handsaw.Padda.Engine/animationInterop.js")
    {
      _stopWatch = Stopwatch.StartNew();
    }

   [JSInvokable]
    public async Task NewFrame() {
      var milliseconds = _stopWatch.ElapsedMilliseconds;
      _stopWatch.Restart();
      await OnAnimationFrame?.Invoke(milliseconds);
    }

    public event Func<long, Task> OnAnimationFrame;

    public override async Task OnInitialized()
    {
      var serviceReference = DotNetObjectReference.Create(this);
      var module = await Module.Value;
      await module.InvokeVoidAsync("startAnimationLoop", serviceReference);
    }
  }
}
