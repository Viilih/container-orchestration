using Microsoft.EntityFrameworkCore;
using Storage.Domain;

namespace Storage.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
    
    public DbSet<Product> Products { get; set; }
    
}