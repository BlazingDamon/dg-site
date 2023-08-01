using FluentValidation;
using FluentValidation.AspNetCore;
using Hellang.Middleware.ProblemDetails;
using Hellang.Middleware.ProblemDetails.Mvc;
using Statistics.API.Services;
using Statistics.Domain.Exceptions;
using Statistics.Models.Players;
using StatisticsRepository.Core.Players;
using StatisticsRepository.MongoDB.Players;
using StatisticsRepository.MongoDB.Scaffolding;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails(
    opt => opt.MapToStatusCode<PlayerNotFoundException>(StatusCodes.Status404NotFound));
builder.Services.AddControllers();
builder.Services.AddProblemDetailsConventions();
builder.Services.AddValidatorsFromAssemblyContaining<PlayerValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddScoped<IPlayerService, PlayerService>()
    .AddScoped<IPlayerRepository, PlayerRepository>();

var mongoSettingsSection = builder.Configuration.GetSection(MongoSettings.SectionKey);
builder.Services.Configure<MongoSettings>(mongoSettingsSection);
builder.Services.AddMongoRepositories(mongoSettingsSection.Get<MongoSettings>());

builder.Services.AddAutoMapper(
    typeof(PlayerDomainProfile),
    typeof(PlayerEntityProfile));

var app = builder.Build();

app.UseProblemDetails();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
