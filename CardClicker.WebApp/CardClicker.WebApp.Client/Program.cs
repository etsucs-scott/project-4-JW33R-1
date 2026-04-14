using CardClicker.Core;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace CardClicker.WebApp.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddSingleton<GameEngine>();
            await builder.Build().RunAsync();
        }
    }
}
