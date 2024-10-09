﻿using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? OrderId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public decimal? Amount { get; set; }

    public string? PaymentMethod { get; set; }

    public decimal? PlatformFee { get; set; }

    public decimal? Discount { get; set; }

    public decimal? NetAmount { get; set; }

    public string? Status { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Order? Order { get; set; }

    public virtual ICollection<TransactionProcess> TransactionProcesses { get; set; } = new List<TransactionProcess>();
}
