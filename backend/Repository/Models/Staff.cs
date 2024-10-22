using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public int? UserId { get; set; }

    public string Role { get; set; } = null!;

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual User? User { get; set; }
}
