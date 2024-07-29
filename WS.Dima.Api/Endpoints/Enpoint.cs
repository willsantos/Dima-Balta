using WS.Dima.Api.Common.Api;
using WS.Dima.Api.Endpoints.Categories;
using WS.Dima.Api.Endpoints.Transactions;

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
                .RequireAuthorization()
                .MapEndPoint<CreateCategoryEndpoint>()
                .MapEndPoint<UpdateCategoryEndpoint>()
                .MapEndPoint<DeleteCategoryEndpoint>()
                .MapEndPoint<GetByIdCategoryEndpoint>()
                .MapEndPoint<GetAllCategoriesEndpoint>();

            Endpoints.MapGroup("v1/transactions")
                .WithTags("Transactions")
                .RequireAuthorization()
                .MapEndPoint<CreateTransactionEndpoint>()
                .MapEndPoint<UpdateTransactionEndpoint>()
                .MapEndPoint<DeleteTransactionEndpoint>()
                .MapEndPoint<GetByIdTransactionEndpoint>()
                .MapEndPoint<GetByPeriodTransactionsEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndPoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }

    }
}
