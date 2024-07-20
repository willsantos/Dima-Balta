using Microsoft.EntityFrameworkCore;
using WS.Dima.Api.Data;
using WS.Dima.Api.Endpoints;
using WS.Dima.Api.Handlers;
using WS.Dima.Core.Handlers;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder
    .Configuration
    .GetConnectionString("DefaultConnection") ?? throw new Exception("Falha em obter connection string");

builder.Services.AddDbContext<AppDbContext>(x =>
    x.UseSqlServer(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapEndpoints();

app.MapGet("/", () => "Hello World!");

app.Run();
