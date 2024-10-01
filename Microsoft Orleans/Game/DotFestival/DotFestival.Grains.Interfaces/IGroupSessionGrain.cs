namespace DotFestival.Grains.Interfaces;

public interface IGroupSessionGrain : IGrainWithStringKey
{
    Task JoinSession(IUserGrain user);
    Task<List<IUserGrain>> GetUsers();
    Task LeaveSession(IUserGrain user);
    Task<string> GetMap();
}
