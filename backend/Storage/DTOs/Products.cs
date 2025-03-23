namespace Storage.DTOs;

public class Products
{
   
}

public class ProductResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public ICollection<ProductImageDto> ProductImages { get; set; } = new List<ProductImageDto>();
}

public class ProductImageDto
{
    public Guid Id { get; set; }
    public string Base64Image { get; set; }
}