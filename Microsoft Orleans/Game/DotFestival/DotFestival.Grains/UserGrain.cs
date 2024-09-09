using DotFestival.Grains.Interfaces;

namespace DotFestival.Grains;

public class UserGrain : IGrain, IUserGrain
{
    private string _name { get; set; }

    public Task CreateGroup()
    {
        throw new NotImplementedException();
    }

    public Task Dance()
    {
        throw new NotImplementedException();
    }

    public Task InviteToGroup(IUserGrain user)
    {
        throw new NotImplementedException();
    }

    public Task LeaveGroup(int groupId)
    {
        throw new NotImplementedException();
    }

    public Task SetName(string name)
    {
        _name = name;
        return Task.CompletedTask;
    }

    public Task<string> GetName()
    {
        return Task.FromResult(_name);
    }

    public Task WalkTo(int x, int y)
    {
        throw new NotImplementedException();
    }
}
