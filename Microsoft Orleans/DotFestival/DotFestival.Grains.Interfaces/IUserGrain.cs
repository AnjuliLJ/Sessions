namespace DotFestival.Grains.Interfaces;

public interface IUserGrain : IGrainWithStringKey
{
    Task<string> GetName();
}
