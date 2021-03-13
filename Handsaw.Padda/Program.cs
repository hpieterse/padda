using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Handsaw.Padda.Engine;
using Microsoft.Extensions.DependencyInjection;
using Handsaw.Padda.Services;
using Blazored.LocalStorage;

namespace Handsaw.Padda
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");

      builder.Services.UseEngine();

      builder.Services.AddTransient<IStorageService,StorageService>();
      builder.Services.AddBlazoredLocalStorage();

      await builder.Build().RunAsync();
    }
  }
}
