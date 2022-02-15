namespace MetaGame.Server.Console.Entities;

public interface IProduct
{
    public string Id { get; }
    
    public IContent[] Content { get; }
}