namespace DotFestival.Grains.Interfaces
{
    public interface IUserGrain : IGrainWithStringKey
    {
        Task WalkTo(Movement movement);
        Task SetName(string name);
        Task SetColor(string color);
        Task<string> GetName();
        Task<int[]> GetPosition();
        Task<string> GetColor();
    }
}
