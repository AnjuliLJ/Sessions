namespace DotFestival.Grains.Interfaces
{
    public interface IUserGrain : IGrainWithStringKey
    {
        Task WalkTo(Movement movement);
        Task SetName(string name);
        Task<string> GetName();
        Task<int[]> GetPosition();
    }
}
