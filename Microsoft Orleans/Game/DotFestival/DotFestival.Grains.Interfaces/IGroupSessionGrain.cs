namespace DotFestival.Grains.Interfaces;

public interface IGroupSessionGrain
{
    Task RegisterUser(IUserGrain user);
    Task<List<IUserGrain>> GetUsers();
    Task Close();
}
