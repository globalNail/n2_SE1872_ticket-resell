﻿using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int? BuyerId { get; set; }

    public int? TicketId { get; set; }

    public int? SellerId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Member? Buyer { get; set; }

    public virtual Member? Seller { get; set; }

    public virtual Ticket? Ticket { get; set; }
}
