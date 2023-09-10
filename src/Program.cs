using System.Threading.Tasks;
using MacOS.Print.Services;
using MacOS.Print.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MacOS.Print;

/// <summary>
/// Entry method.
/// </summary>
public class Program
{
    /// <summary>
    /// Main entry point.
    /// </summary>
    /// <param name="args">arguments.</param>
    public static async Task Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);

        builder.Services.AddHostedService<ProgramHost>();
        builder.Services.AddSingleton<IPrinterService, PrinterService>();

        using var host = builder.Build();

        await host.RunAsync().ConfigureAwait(false);
    }
}
