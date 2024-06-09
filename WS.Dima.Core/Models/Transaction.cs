﻿using WS.Dima.Core.Enums;

namespace WS.Dima.Core.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? PaidOrReceivedAt { get; set; }
        public decimal Amount { get; set; }
        public ETransactionType Type { get; set; } = ETransactionType.Withdraw;
        public string UserId { get; set; } = string.Empty;
        public long CategoryId { get; set; }
        public Category Category { get; set; } = new Category();

    }
}
