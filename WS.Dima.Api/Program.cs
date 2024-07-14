using Microsoft.EntityFrameworkCore;
using WS.Dima.Api.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder
    .Configuration
    .GetConnectionString("DefaultConnection") ?? throw new Exception("Falha em obter connection string");

builder.Services.AddDbContext<AppDbContext>(x =>
    x.UseSqlServer(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.Run();
