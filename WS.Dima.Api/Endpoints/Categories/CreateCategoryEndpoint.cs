using WS.Dima.Api.Common.Api;
using WS.Dima.Core.Handlers;
using WS.Dima.Core.Models;
using WS.Dima.Core.Requests.Categories;
using WS.Dima.Core.Responses;

namespace WS.Dima.Api.Endpoints.Categories
{
    public class CreateCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Categorias: Criar")
            .WithSummary("Cria uma nova categoria")
            .WithDescription("descrição longa, Cria uma nova categoria")
            .WithOrder(1)
            .Produces<Response<Category?>>(StatusCodes.Status201Created)
            .Produces<Response<Category?>>(StatusCodes.Status400BadRequest);


        private static async Task<IResult> HandleAsync(ICategoryHandler handler, CreateCategoryRequest request)
        {
            var result = await handler.CreateAsync(request);
            return result.IsSucess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result);
        }
    }
}