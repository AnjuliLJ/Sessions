namespace DotFestival.Grains.Interfaces
{
    public interface IUserGrain : IGrainWithStringKey
    {
        Task CreateGroup();
        Task InviteToGroup(IUserGrain user);
        Task Dance();
        Task WalkTo(int x, int y);
        Task SetName(string name);
        Task<string> GetName();
        Task LeaveGroup(int groupId);
    }
}
