using System.Security.Claims;
using WS.Dima.Api.Common.Api;
using WS.Dima.Core.Handlers;
using WS.Dima.Core.Models;
using WS.Dima.Core.Requests.Categories;
using WS.Dima.Core.Responses;

namespace WS.Dima.Api.Endpoints.Categories
{
    public class UpdateCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Categorias: Atualizar")
            .WithSummary("Atualizar uma categoria")
            .WithDescription("descrição longa, Atualizar uma categoria")
            .WithOrder(2)
            .Produces<Response<Category?>>(StatusCodes.Status200OK)
            .Produces<Response<Category?>>(StatusCodes.Status400BadRequest);

        private static async Task<IResult> HandleAsync(
            ICategoryHandler handler,
            UpdateCategoryRequest request,
            ClaimsPrincipal user,
            long id
            )
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            request.Id = id;

            var result = await handler.UpdateAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}



