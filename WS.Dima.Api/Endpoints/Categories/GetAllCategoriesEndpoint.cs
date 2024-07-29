using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WS.Dima.Api.Common.Api;
using WS.Dima.Core;
using WS.Dima.Core.Handlers;
using WS.Dima.Core.Models;
using WS.Dima.Core.Requests.Categories;
using WS.Dima.Core.Responses;

namespace WS.Dima.Api.Endpoints.Categories
{
    public class GetAllCategoriesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Categorias: Obter todas")
            .WithSummary("Obter Todas categoria")
            .WithDescription("descrição longa, Obter Todas categoria")
            .Produces<PagedResponse<List<Category>>>(StatusCodes.Status200OK)
            .Produces<Response<Category?>>(StatusCodes.Status400BadRequest);

        private static async Task<IResult> HandleAsync(
           ICategoryHandler handler,
           ClaimsPrincipal user,
           [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
           [FromQuery] int pageSize = Configuration.DefaultPageSize
           )
        {
            var request = new GetAllCategoriesRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                PageNumber = pageNumber,
                PageSize = pageSize
            };


            var result = await handler.GetAllAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
