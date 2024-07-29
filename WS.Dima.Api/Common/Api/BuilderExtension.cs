using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WS.Dima.Api.Data;
using WS.Dima.Api.Handlers;
using WS.Dima.Api.Models;
using WS.Dima.Core;
using WS.Dima.Core.Handlers;

namespace WS.Dima.Api.Common.Api;

public static class BuilderExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.ConnectionString = builder
            .Configuration
            .GetConnectionString("DefaultConnection") ?? string.Empty;
        
        Configuration.BackendUrl = builder
            .Configuration
            .GetValue<string>("BackendUrl") ?? string.Empty;
        
        Configuration.FrontendUrl = builder
            .Configuration
            .GetValue<string>("FrontendUrl") ?? string.Empty;
    }
    
    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();
    }
    
    public static void AddSecurity(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
            .AddIdentityCookies();
        builder.Services.AddAuthorization();
    }
    
    public static void AddDataContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(x =>
            x.UseSqlServer(Configuration.ConnectionString));
        
        builder.Services.AddIdentityCore<User>()
            .AddRoles<IdentityRole<long>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddApiEndpoints();
    }
    
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
        builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();
    }
    
    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(
                ApiConfiguration.CorsPolicyName,            
                policy => policy
                    .WithOrigins([
                        Configuration.BackendUrl,
                        Configuration.FrontendUrl
                    ])
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
            );
        });
    }
}