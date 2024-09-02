using Orleans.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DotFestival.Grains.Interfaces;


IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(client =>
    {
        client.UseLocalhostClustering();
    })
    .ConfigureLogging(logging => logging.AddConsole())
    .UseConsoleLifetime();

using IHost host = builder.Build();
await host.StartAsync();

IClusterClient client = host.Services.GetRequiredService<IClusterClient>();

IUserGrain user = client.GetGrain<IUserGrain>("David");
string name = await user.GetName();

Console.WriteLine($"""
    Name of the user is: {name}

    Press any key to exit...
    """);

Console.ReadKey();

await host.StopAsync();