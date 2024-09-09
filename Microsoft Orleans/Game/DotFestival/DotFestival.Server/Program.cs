using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .UseOrleans(siloBuilder =>
    {
        siloBuilder.UseLocalhostClustering();
    })
    .Build();

await host.StartAsync();

Console.ReadLine();