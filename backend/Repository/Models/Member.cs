﻿using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public int? UserId { get; set; }

    public decimal? AverageRating { get; set; }

    public int? RatingCount { get; set; }

    public DateTime? MembershipDate { get; set; }

    public string? MembershipStatus { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<Feedback> FeedbackBuyers { get; set; } = new List<Feedback>();

    public virtual ICollection<Feedback> FeedbackSellers { get; set; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual User? User { get; set; }
}
