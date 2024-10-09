﻿using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public string Barcode { get; set; } = null!;

    public decimal Price { get; set; }

    public int? Quantity { get; set; }

    public string? SeatNumber { get; set; }

    public int? SellerId { get; set; }

    public int? CategoryId { get; set; }

    public string? PdfFile { get; set; }

    public string? Status { get; set; }

    public DateTime? PostedAt { get; set; }

    public int? ApprovedBy { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public string? ProcessingNotes { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Staff? ApprovedByNavigation { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Member? Seller { get; set; }

    public virtual ICollection<TransactionProcess> TransactionProcesses { get; set; } = new List<TransactionProcess>();
}
