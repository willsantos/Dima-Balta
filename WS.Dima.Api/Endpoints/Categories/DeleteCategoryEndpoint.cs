using WS.Dima.Api.Common.Api;
using WS.Dima.Core.Handlers;
using WS.Dima.Core.Models;
using WS.Dima.Core.Requests.Categories;
using WS.Dima.Core.Responses;

namespace WS.Dima.Api.Endpoints.Categories
{
    public class DeleteCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandleAsync)
            .WithName("Categorias: Excluir")
            .WithSummary("Excluir uma categoria")
            .WithDescription("descrição longa, Excluir uma categoria")
            .Produces<Response<Category?>>(StatusCodes.Status200OK)
            .Produces<Response<Category?>>(StatusCodes.Status400BadRequest);

        private static async Task<IResult> HandleAsync(
           ICategoryHandler handler,
           long id
           )
        {
            var request = new DeleteCategoryRequest
            {
                UserId = "teste@wilsonsantos.com.br",
                Id = id
            };

            var result = await handler.DeleteAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
