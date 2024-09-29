using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? ImageUrl { get; set; }

    public string Role { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
