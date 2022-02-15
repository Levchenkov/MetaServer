namespace MetaGame.Server.Console.Configurations;

public class ShopConfiguration : IShopConfiguration
{
    public int GetPrice(string productId) => 42;
}