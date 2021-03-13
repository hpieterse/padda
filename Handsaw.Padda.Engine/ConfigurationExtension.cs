using Microsoft.Extensions.DependencyInjection;
using Handsaw.Padda.Engine.Services;
using Microsoft.JSInterop;

namespace Handsaw.Padda.Engine
{
  /// <summary>
  /// Extensions for setup up the game engine
  /// </summary>
  public static class ConfigurationExtension
  {
    /// <summary>
    /// Set up dependencies
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static void UseEngine(this IServiceCollection serviceCollection)
    {
      serviceCollection.AddTransient<IWindowResizeService, WindowResizeService>();
      serviceCollection.AddTransient<ICanvasService, CanvasService>();
      serviceCollection.AddTransient<IAnimationService, AnimationService>();
      serviceCollection.AddSingleton(serviceProvider => (IJSUnmarshalledRuntime)serviceProvider.GetRequiredService<IJSRuntime>());
      serviceCollection.AddSingleton<IInteropLoadService, InteropLoadService>();
      serviceCollection.AddSingleton<IAudioService, AudioService>();
    }
  }

}
