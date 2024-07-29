using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WS.Dima.Api.Data;
using WS.Dima.Api.Endpoints;
using WS.Dima.Api.Handlers;
using WS.Dima.Api.Models;
using WS.Dima.Core.Handlers;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddIdentityCookies();
builder.Services.AddAuthorization();

var connectionString = builder
    .Configuration
    .GetConnectionString("DefaultConnection") ?? throw new Exception("Falha em obter connection string");

builder.Services.AddDbContext<AppDbContext>(x =>
    x.UseSqlServer(connectionString));

builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole<long>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();



app.MapGet("/", () => "Hello World!");
app.MapEndpoints();
app.MapGroup("v1/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();
app.MapGroup("v1/identity")
    .WithTags("Identity")
    .MapPost("/logout", async (
        SignInManager<User> signInManager
    ) =>
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    }).RequireAuthorization();

app.MapGroup("v1/identity")
    .WithTags("Identity")
    .MapGet("/roles", async (ClaimsPrincipal user) =>
    {
        if(user.Identity is null || !user.Identity.IsAuthenticated)
            return Results.Unauthorized();
        
        var identity = user.Identity as ClaimsIdentity;
        var roles = identity?
            .FindAll(ClaimTypes.Role)
            .Select(x => new
            {
                x.Issuer,
                x.OriginalIssuer,
                x.Type,
                x.Value,
                x.ValueType
            });
        
        return TypedResults.Ok(roles);
    }).RequireAuthorization();
    

app.Run();
