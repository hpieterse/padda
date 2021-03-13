using System;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Handsaw.Padda.Engine.Services
{
  internal class WindowResizeService : UnmarshalledInteropServiceBase, IWindowResizeService
  {

    public event Action<SizeF> OnWindowResize;

    public WindowResizeService(IInteropLoadService loadService) : base(loadService, "_content/Handsaw.Padda.Engine/windowResizeInterop.js")
    {
    }

    [JSInvokable]
    public void OnSizeChanged(float width, float height)
    {
      OnWindowResize?.Invoke(new SizeF(width, height));
    }

    public override async Task OnInitialized()
    {
      var serviceReference = DotNetObjectReference.Create(this);
      var module = await Module.Value;
      await module.InvokeVoidAsync("startListener", serviceReference);
    }
  }
}

