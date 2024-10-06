using DotFestival.Grains.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

using var host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(clientBuilder =>
        clientBuilder.UseLocalhostClustering())
    .Build();

await host.StartAsync();

Console.WriteLine("Connected to server\n");

var client = host.Services.GetRequiredService<IClusterClient>();


Console.WriteLine("What is your name?");

var name = Console.ReadLine();

var user = client.GetGrain<IUserGrain>(name);
await user.SetName(name);

Console.WriteLine("Choose a color: blue, green or black");

var color = Console.ReadLine();
var colorCode = color switch
{
    "blue" => "#0000FF",
    "green" => "#008000",
    "black" => "#000000",
    _ => "#FFFFFF"
};

await user.SetColor(colorCode);

Console.WriteLine($"Welcome to the .NET Festival {name}");

var session = client.GetGrain<IGroupSessionGrain>("1");
await session.JoinSession(user);
var command = "";
while (command != "Quit")
{
    command = Console.ReadLine();
    var direction = command switch
    {
        "u" => Movement.Up,
        "d" => Movement.Down,
        "l" => Movement.Left,
        "r" => Movement.Right,
        _ => Movement.Up
    };
    await user.WalkTo(direction);
}

Console.WriteLine("Bye, see you next time!");

Console.ReadLine();

return;
