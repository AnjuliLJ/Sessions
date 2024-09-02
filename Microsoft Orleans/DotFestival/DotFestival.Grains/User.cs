using DotFestival.Grains.Interfaces;

namespace DotFestival.Grains;

public class User : IGrain, IUserGrain
{
    public Task<string> GetName()
    {
        return Task.FromResult("David");
    }
}
