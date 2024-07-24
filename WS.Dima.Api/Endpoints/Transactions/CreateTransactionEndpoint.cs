﻿using System.Security.Claims;
using WS.Dima.Api.Common.Api;
using WS.Dima.Core.Handlers;
using WS.Dima.Core.Models;
using WS.Dima.Core.Requests.Transactions;
using WS.Dima.Core.Responses;

namespace WS.Dima.Api.Endpoints.Transactions
{
    public class CreateTransactionEndpoint : IEndpoint
    {

        public static void Map(IEndpointRouteBuilder app)
    => app.MapPost("/", HandleAsync)
        .WithName("Transactions: Create")
        .WithSummary("Cria uma nova transação")
        .WithDescription("Cria uma nova transação")
        .WithOrder(1)
        .Produces<Response<Transaction?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ITransactionHandler handler,
            CreateTransactionRequest request)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.CreateAsync(request);
            return result.IsSucess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result.Data);
        }
    }
}

