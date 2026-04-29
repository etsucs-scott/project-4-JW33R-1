using CardClicker.Core;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Magic.IndexedDb;

namespace CardClicker.WebApp.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddSingleton<GameEngine>();
            builder.Services.AddMagicBlazorDB(BlazorInteropMode.WASM, builder.HostEnvironment.IsDevelopment()); //Puts the database in the browser's IndexedDB, and enables logging in development mode
            await builder.Build().RunAsync();
        }
    }
}
