using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace MetaGame.Server.Console.Controllers;

[ApiController]
[Route("[controller]")]
public class MetaGameController : ControllerBase
{
    private readonly IShopService _shopService;

    public MetaGameController()
    {
        _shopService = new ShopService();
    }

    [HttpPost(template: "BuyProduct/{productId}")]
    public IProduct BuyProduct(string productId) => _shopService.BuyProduct(User.GetId(), productId);
}

public static class Extensions
{
    public static Guid GetId(this ClaimsPrincipal user) => Guid.NewGuid();
}

public interface IProduct
{
    string Id { get; }
    
    IContent[] Content { get; }
}

public record Box(string Id, IContent[] Content) : IProduct;

public interface IContent
{
    string Id { get; }
}

public record Brawler(string Id) : IContent;

public interface IShopService
{
    IProduct BuyProduct(Guid playerId, string productId);
}

public interface IPlayerService
{
    bool DoesPlayerExist(Guid playerId);
    
    bool CanPlayerPayPrice(Guid playerId, int price);

    void PayPrice(Guid playerId, int price);

    void ApplyContent(IContent[] content);
}

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

public class ShopService : IShopService
{
    private readonly IPlayerService _playerService;
    private readonly IShopConfiguration _shopConfiguration;

    public ShopService()
    {
        _playerService = new PlayerService();
        _shopConfiguration = new ShopConfiguration();
    }

    public IProduct BuyProduct(Guid playerId, string productId)
    {
        if (!_playerService.DoesPlayerExist(playerId))
        {
            throw new Exception("Player doesn't exist");
        }

        var price = _shopConfiguration.GetPrice(productId);

        if (!_playerService.CanPlayerPayPrice(playerId, price))
        {
            throw new Exception("Not enough money");
        }
        
        _playerService.PayPrice(playerId, price);
        
        IContent[] content = new[] { new Brawler("Spike") };
        
        _playerService.ApplyContent(content);

        return new Box(productId, content);
    }
}

public interface IShopConfiguration
{
    int GetPrice(string productId);
}

public class ShopConfiguration : IShopConfiguration
{
    public int GetPrice(string productId) => 42;
}