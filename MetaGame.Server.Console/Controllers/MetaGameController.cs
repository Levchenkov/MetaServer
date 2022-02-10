using MetaGame.Server.Console.Entities;
using MetaGame.Server.Console.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetaGame.Server.Console.Controllers;

[ApiController]
[Route("[controller]")]
public class MetaGameController : ControllerBase
{
    private readonly IShopService _shopService;

    public MetaGameController() => _shopService = new ShopService();

    [HttpPost]
    public IProduct BuyProduct(string productId) => _shopService.BuyProduct(User.GetId(), productId);
}