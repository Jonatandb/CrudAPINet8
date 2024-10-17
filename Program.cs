using CrudAPINet8.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("CRUDAPINET8_NEONCONNECTIONSTRING")
                        ?? builder.Configuration.GetConnectionString("ProductDbContext");

builder.Services.AddDbContext<ProductDbContext>(options => options.UseNpgsql(connectionString ?? throw new InvalidOperationException("Connection string 'ProductDbContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Console.WriteLine($"Connection string: {connectionString}");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Use(async (context, next) => {
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
    await next.Invoke();
});

app.MapControllers();

app.Run();
