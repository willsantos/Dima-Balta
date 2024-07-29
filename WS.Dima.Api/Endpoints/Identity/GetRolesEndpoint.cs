using System.Security.Claims;
using WS.Dima.Api.Common.Api;

namespace WS.Dima.Api.Endpoints.Identity;

public class GetRolesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app
        .MapGet("/roles", Handle)
        .RequireAuthorization();

    private static Task<IResult> Handle(ClaimsPrincipal user)
    {
        if(user.Identity is null || !user.Identity.IsAuthenticated)
            return Task.FromResult(Results.Unauthorized());
        
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
        
        return Task.FromResult<IResult>(TypedResults.Json(roles));
    }
}