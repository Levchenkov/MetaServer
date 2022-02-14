using MetaGame.Server.Console.Entities;

namespace MetaGame.Server.Console.Services;

public interface IPlayerService
{
    bool DoesPlayerExist(Guid playerId);
    
    bool CanPlayerPayPrice(Guid playerId, int price);

    void PayPrice(Guid playerId, int price);

    void ApplyContent(IContent[] content);
}