using DotFestival.Grains.Interfaces;
using System.Text;

namespace DotFestival.Grains;

public class GroupSessionGrain : IGroupSessionGrain
{
    private List<IUserGrain> _users = new List<IUserGrain>();

    public Task<List<IUserGrain>> GetUsers()
    {
        return Task.FromResult(_users);
    }

    public Task JoinSession(IUserGrain user)
    {
        _users.Add(user);
        return Task.CompletedTask;
    }

    public Task LeaveSession(IUserGrain user)
    {
        if (_users.Contains(user))
        {
            _users.Remove(user);
        }
        return Task.CompletedTask;
    }

    public Task<string> GetMap()
    {
        int width = 40;
        int height = 20;
        char[,] map = new char[width, height];

        Random rand = new Random();
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (y == 0 ||
                    y == (height - 1))
                {
                    map[x, y] = '-';
                } else if (x == 0 || x == (width - 1))
                {
                    map[x, y] = '|';
                }
                else
                {
                    map[x, y] = ' ';
                }
            }
        }

        foreach (var user in _users)
        {
            var position = user.GetPosition().Result;
            var name = user.GetName().Result;
            if (string.IsNullOrEmpty(name)) map[position[0], position[1]] = '.';
            else
            {
                map[position[0], position[1]] = name[0];
            }
        }


        map = AddStage(map);

        StringBuilder sb = Draw(width, height, map);

        return Task.FromResult(sb.ToString());
    }

    private StringBuilder Draw(int width, int height, char[,] map)
    {
        StringBuilder sb = new StringBuilder();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                sb.Append(map[x, y]);
            }
            sb.AppendLine();
        }

        return sb;
    }

    private char[,] AddStage(char[,] map)
    {
        map[13, 1] = '|';
        map[14, 1] = 'M';
        map[15, 1] = 'A';
        map[16, 1] = 'I';
        map[17, 1] = 'N';
        map[18, 1] = 'S';
        map[19, 1] = 'T';
        map[20, 1] = 'A';
        map[21, 1] = 'G';
        map[22, 1] = 'E';
        map[23, 1] = '|';

        map[13, 2] = '|';
        map[14, 2] = '_';
        map[15, 2] = '_';
        map[16, 2] = '_';
        map[17, 2] = '_';
        map[18, 2] = '_';
        map[19, 2] = '_';
        map[20, 2] = '_';
        map[21, 2] = '_';
        map[22, 2] = '_';
        map[23, 2] = '|';
        return map;

    }
}
