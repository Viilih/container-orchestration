namespace Storage.Domain;

public class Product
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Price { get; set; }
    
    public string? ImageUrl { get; set; }
}