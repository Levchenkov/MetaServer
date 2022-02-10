using MetaGame.Server.Console.Entities;

namespace MetaGame.Server.Console.Services;

public interface IShopService
{
    IProduct BuyProduct(Guid playerId, string productId);
}