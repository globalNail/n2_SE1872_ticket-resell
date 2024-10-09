﻿using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int? OrderId { get; set; }

    public int? TicketId { get; set; }

    public int? Quantity { get; set; }

    public decimal? UnitPrice { get; set; }

    public decimal? TotalPrice { get; set; }

    public DateTime? AddedAt { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Ticket? Ticket { get; set; }
}
