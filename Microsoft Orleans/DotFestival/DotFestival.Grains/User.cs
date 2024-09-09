using DotFestival.Grains.Interfaces;
using Orleans.Concurrency;

namespace DotFestival.Grains;

public class User : IGrain, IUserGrain
{
    public Task<string> GetName()
    {
        return Task.FromResult("David");
    }
}
