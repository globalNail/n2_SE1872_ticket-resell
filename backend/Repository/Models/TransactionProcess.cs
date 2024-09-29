using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class TransactionProcess
{
    public int TransactionProcessId { get; set; }

    public int? TransactionId { get; set; }

    public int? TicketId { get; set; }

    public string? Status { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Notes { get; set; }

    public virtual Ticket? Ticket { get; set; }

    public virtual Transaction? Transaction { get; set; }
}
