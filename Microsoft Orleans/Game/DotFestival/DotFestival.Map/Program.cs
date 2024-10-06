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


var group = client.GetGrain<IGroupSessionGrain>("1");
while (true)
{
    var game = await group.GetMap();
    Console.WriteLine(game);
    Task.Delay(200).Wait();
}