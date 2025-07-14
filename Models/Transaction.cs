using System;
using System.Collections.Generic;

namespace SeoulStay.Models;

public partial class Transaction
{
    public long Id { get; set; }

    public Guid Guid { get; set; }

    public long UserId { get; set; }

    public long TransactionTypeId { get; set; }

    public decimal Amount { get; set; }

    public DateOnly TransactionDate { get; set; }

    public string GatewayReturnId { get; set; } = null!;

    public virtual TransactionType TransactionType { get; set; } = null!;
}
