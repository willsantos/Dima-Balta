using Microsoft.AspNetCore.Identity;
using WS.Dima.Api.Common.Api;
using WS.Dima.Api.Models;

namespace WS.Dima.Api.Endpoints.Identity;

public class LogoutEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app
            .MapPost("/logout", HandleAsync)
            .RequireAuthorization();

    private static async Task<IResult> HandleAsync(SignInManager<User> signInManager)
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    }
}