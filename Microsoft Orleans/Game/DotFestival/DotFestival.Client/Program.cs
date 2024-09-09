using DotFestival.Grains.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(clientBuilder =>
        clientBuilder.UseLocalhostClustering())
    .Build();

await host.StartAsync();

Console.WriteLine("Connected to server");

var client = host.Services.GetRequiredService<IClusterClient>();

var command = Console.ReadLine();

if (command == "David")
{
    var player = client.GetGrain<IUserGrain>(command);
    await player.SetName("David");
    Console.WriteLine("Name set to David");

    var name = await player.GetName();
    Console.WriteLine($"Name is {name}");
}

Console.ReadLine();