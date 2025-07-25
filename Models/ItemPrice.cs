﻿using System;
using System.Collections.Generic;

namespace SeoulStay.Models;

public partial class ItemPrice
{
    public long Id { get; set; }

    public Guid Guid { get; set; }

    public long ItemId { get; set; }

    public DateOnly Date { get; set; }

    public decimal Price { get; set; }

    public long CancellationPolicyId { get; set; }

    public virtual CancellationPolicy CancellationPolicy { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;
}
