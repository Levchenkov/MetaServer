using MetaGame.Server.Console.Configurations;
using MetaGame.Server.Console.Entities;

namespace MetaGame.Server.Console.Services;

public class ShopService : IShopService
{
    private readonly IShopConfiguration _shopConfiguration;
    private readonly IPlayerService _playerService;

    public ShopService()
    {
        _shopConfiguration = new ShopConfiguration();
        _playerService = new PlayerService();
    }

    public IProduct BuyProduct(Guid playerId, string productId)
    {
        if (!_playerService.DoesPlayerExist(playerId))
        {
            throw new Exception("Player doesn't exist.");
        }

        var price = _shopConfiguration.GetPrice(productId);

        if (!_playerService.CanPlayerPayPrice(playerId, price))
        {
            throw new Exception("Not enough resources.");
        }
        
        _playerService.PayPrice(playerId, price);

        IContent[] content = new[] { new Brawler("Spike") };

        _playerService.ApplyContent(content);
        
        return new Box(productId, content);
    } 
}