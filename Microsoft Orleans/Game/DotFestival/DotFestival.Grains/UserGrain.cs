using DotFestival.Grains.Interfaces;
using Orleans.Concurrency;

namespace DotFestival.Grains;

public class UserGrain : IGrain, IUserGrain
{
    private string _name { get; set; } = string.Empty;
    private int[] _position { get; set; } = [5, 5];
    private string _color { get; set; } = "#FF0000";

    public Task SetName(string name)
    {
        _name = name;
        
        return Task.CompletedTask;
    }

    public Task<string> GetName()
    {
        return Task.FromResult(_name);
    }

    public Task WalkTo(Movement movement)
    {
         if (movement == Movement.Up && _position[1] > 1) _position[1] -= 1;
        if (movement == Movement.Down && _position[1] < 18) _position[1] += 1;
        if (movement == Movement.Left && _position[0] > 1) _position[0] -= 1;
        if (movement == Movement.Right && _position[0] < 38) _position[0] += 1;
        return Task.CompletedTask;
    }

    public Task<int[]> GetPosition()
    {
        return Task.FromResult(_position);
    }

    public Task SetColor(string color)
    {
        _color = color;
        return Task.CompletedTask;
    }

    public Task<string> GetColor()
    {
       return Task.FromResult(_color);
    }
}
