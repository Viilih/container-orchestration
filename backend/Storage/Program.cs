using Microsoft.EntityFrameworkCore;
using Storage.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:5173").AllowAnyMethod() // ✅ Allows GET, POST, PUT, DELETE, etc.
              .AllowAnyHeader();;
        });
});
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.MigrateAndSeed(services);
}

app.UseStaticFiles(); // Enables serving static files like images


app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();


app.MapControllers();

app.Run();
