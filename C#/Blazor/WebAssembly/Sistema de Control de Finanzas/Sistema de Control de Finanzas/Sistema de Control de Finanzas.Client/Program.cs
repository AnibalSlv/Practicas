using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Sistema_de_Control_de_Finanzas.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            await builder.Build().RunAsync();
        }
    }
}
