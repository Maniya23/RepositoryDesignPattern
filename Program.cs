using RepositoryDesignPattern.Services.ImplementationClasses;
using RepositoryDesignPattern.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Here we can say what class to be used when IWeatherForecastService is getting used 
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastServiceExtended>();
builder.Services.AddScoped<ITodoService, TodoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
