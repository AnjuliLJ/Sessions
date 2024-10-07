using DotFestival.Grains.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseOrleans(siloBuilder =>
{
    siloBuilder.UseLocalhostClustering();
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/RegisterUsers", async (IGrainFactory grains) =>
{
    var users = new List<IUserGrain>();
    var session = grains.GetGrain<IGroupSessionGrain>("1");

    for (int i = 0; i < 5; i++)
    {
        var user = grains.GetGrain<IUserGrain>($"Bot{i}");
        await user.SetName($".{i}");
        await session.JoinSession(user);
    }
    return users;
});

app.MapGet("/Simulate", async (IGrainFactory grains, List<string> userNames) =>
{
    Random random = new Random();

    foreach (var u in userNames)
    {
        var user = grains.GetGrain<IUserGrain>(u);

        var direction = random.Next(0, 4) switch
        {
            0 => Movement.Up,
            1 => Movement.Down,
            2 => Movement.Left,
            3 => Movement.Right,
            _ => Movement.Up
        };
        await user.WalkTo(direction);
    }
});

app.Run();
