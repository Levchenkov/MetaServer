using MetaGame.Server.Console.Entities;

namespace MetaGame.Server.Console.Services;

public class PlayerService : IPlayerService
{
    public bool DoesPlayerExist(Guid playerId) => true;
    

    public bool CanPlayerPayPrice(Guid playerId, int price) => true;

    public void PayPrice(Guid playerId, int price)
    {
    }

    public void ApplyContent(IContent[] content)
    {
    }
}