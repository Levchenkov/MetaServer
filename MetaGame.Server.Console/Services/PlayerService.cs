using MetaGame.Server.Console.Entities;

namespace MetaGame.Server.Console.Services;

public class PlayerService : IPlayerService
{
    private readonly Dictionary<Guid, Player> _players;

    public PlayerService()
    {
        _players = new Dictionary<Guid, Player>();
    }

    public bool DoesPlayerExist(Guid playerId) => true;
    

    public bool CanPlayerPayPrice(Guid playerId, int price) => true;

    public void PayPrice(Guid playerId, int price)
    {
        
    }
}