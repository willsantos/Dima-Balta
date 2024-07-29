using System.Security.Claims;
using WS.Dima.Api.Common.Api;
using WS.Dima.Core.Handlers;
using WS.Dima.Core.Models;
using WS.Dima.Core.Requests.Categories;
using WS.Dima.Core.Responses;

namespace WS.Dima.Api.Endpoints.Categories
{
    public class GetByIdCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Categorias: Obter")
            .WithSummary("Obter uma categoria")
            .WithDescription("descrição longa, Obter uma categoria")
            .Produces<Response<Category?>>(StatusCodes.Status200OK)
            .Produces<Response<Category?>>(StatusCodes.Status400BadRequest);

        private static async Task<IResult> HandleAsync(
           ICategoryHandler handler,
           ClaimsPrincipal user,
           long id
           )
        {
            var request = new GetByIdCategoryRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                Id = id
            };

            var result = await handler.GetByIdAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
