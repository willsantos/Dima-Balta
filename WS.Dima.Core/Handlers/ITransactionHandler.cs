using WS.Dima.Core.Models;
using WS.Dima.Core.Requests.Transactions;
using WS.Dima.Core.Responses;

namespace WS.Dima.Core.Handlers
{
    public interface ITransactionHandler
    {
        Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request);
        Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request);
        Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request);
        Task<Response<Transaction?>> GetByIdAsync(GetByIdTransactionRequest request);
        Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetByPeriodTransactionsRequest request);
    }
}
