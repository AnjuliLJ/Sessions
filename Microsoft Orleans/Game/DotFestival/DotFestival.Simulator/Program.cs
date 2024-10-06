using DotFestival.Grains.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(clientBuilder =>
        clientBuilder.UseLocalhostClustering())
    .Build();


await host.StartAsync();

Console.WriteLine("Connected to server\n");

var client = host.Services.GetRequiredService<IClusterClient>();
var session = client.GetGrain<IGroupSessionGrain>("1");
await SimulateMovement(client, session);

static List<IUserGrain> RegisterUsers(IClusterClient client)
{
    var users = new List<IUserGrain>();
    for (int i = 0; i < 10; i++)
    {
        var user = client.GetGrain<IUserGrain>($"Bot{i}");
        user.SetName($".{i}");
        users.Add(user);
    }
    return users;
}

static async Task SimulateMovement(IClusterClient client, IGroupSessionGrain session)
{
    Random random = new Random();

    var users = RegisterUsers(client);

    users.ForEach(user => session.JoinSession(user));

    while (true)
    {
        foreach (var u in users)
        {
            var direction = random.Next(0, 4) switch
            {
                0 => Movement.Up,
                1 => Movement.Down,
                2 => Movement.Left,
                3 => Movement.Right,
                _ => Movement.Up
            };
            await u.WalkTo(direction);
            Task.Delay(500).Wait();
        }
    }
}