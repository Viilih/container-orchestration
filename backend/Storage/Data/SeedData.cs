using Microsoft.EntityFrameworkCore;
using Storage.Domain;

namespace Storage.Data;

public static class SeedData
{
    public static void MigrateAndSeed(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
        if (!context.Products.Any())
        {
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Cap",
                    Price = 1499,
                    ImageUrl = "/images/cap.jpg"
                },
                new Product
                {
                    Name = "Jacket",
                    Price = 4999,
                    ImageUrl = "/images/jacket.webp"
                },
                new Product
                {
                    Name = "Jeans",
                    Price = 2999,
                    ImageUrl = "/images/jeans.jpg"
                },
                new Product
                {
                    Name = "T-Shirt",
                    Price = 1299,
                    ImageUrl = "/images/tshirt.png"
                }
            };
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}