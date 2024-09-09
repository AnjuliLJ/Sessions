using DotFestival.Grains.Interfaces;

namespace DotFestival.Server;

public class Game
{
    private readonly IGrainFactory _client;

    public Game(IGrainFactory client) => _client = client;

    public Task Configure()
    {
        // Create stages and set data

        _client.GetGrain<IStageGrain>(new Guid());
        return Task.CompletedTask;
    }
}
