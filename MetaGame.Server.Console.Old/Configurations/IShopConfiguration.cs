namespace MetaGame.Server.Console.Configurations;

public interface IShopConfiguration
{
    int GetPrice(string productId);
}