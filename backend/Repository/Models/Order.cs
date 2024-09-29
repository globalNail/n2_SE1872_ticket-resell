using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Status { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Transaction? Transaction { get; set; }

    public virtual User? User { get; set; }
}
