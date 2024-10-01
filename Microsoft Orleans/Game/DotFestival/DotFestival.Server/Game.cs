using DotFestival.Grains.Interfaces;
using System.Text;

namespace DotFestival.Server;

public class Game
{
    private readonly IGrainFactory _client;
    private List<string> _users = new List<string>();

    private readonly int[,] _map = new int[20, 30];

    public Game(IGrainFactory client) => _client = client;

    public Task Configure()
    {
        return Task.CompletedTask;
    }

}
