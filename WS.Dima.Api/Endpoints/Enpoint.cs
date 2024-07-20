using WS.Dima.Api.Common.Api;
using WS.Dima.Api.Endpoints.Categories;

namespace WS.Dima.Api.Endpoints
{
    public static class Enpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var Endpoints = app
                .MapGroup("");

            Endpoints.MapGroup("/v1/categories")
                .WithTags("Categories")
                .MapEndPoint<CreateCategoryEndpoint>()
                .MapEndPoint<UpdateCategoryEndpoint>()
                .MapEndPoint<DeleteCategoryEndpoint>()
                .MapEndPoint<GetByIdCategoryEndpoint>()
                .MapEndPoint<GetAllCategoriesEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndPoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }

    }
}
