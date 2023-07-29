using Statistics.API.Services;
using Statistics.Models.Players;
using StatisticsRepository.Core.Players;
using StatisticsRepository.MongoDB.Players;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddScoped<IPlayerService, PlayerService>()
    .AddScoped<IPlayerRepository, PlayerRepository>();

builder.Services.AddAutoMapper(typeof(Player));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
