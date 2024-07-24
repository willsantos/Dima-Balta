namespace WS.Dima.Core.Requests.Transactions
{
    public class GetByPeriodTransactionsRequest : PagedRequest
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}