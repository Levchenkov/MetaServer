namespace MetaGame.Server.Console.Entities;

public record Box(string Id, IContent[] Content) : IProduct;