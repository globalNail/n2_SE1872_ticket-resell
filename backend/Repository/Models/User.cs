using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? ImageUrl { get; set; }

    public decimal? AverageRating { get; set; }

    public int? RatingCount { get; set; }

    public int? RoleId { get; set; }

    public int? WalletId { get; set; }

    public virtual ICollection<Feedback> FeedbackBuyers { get; set; } = new List<Feedback>();

    public virtual ICollection<Feedback> FeedbackSellers { get; set; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual UserRole? Role { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual Wallet? Wallet { get; set; }
}
