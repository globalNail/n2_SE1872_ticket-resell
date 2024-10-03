using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Business
{
    public int BusinessId { get; set; }

    public int? UserId { get; set; }

    public int? PackageId { get; set; }

    public string BusinessName { get; set; } = null!;

    public DateTime? RegistrationDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public string? Status { get; set; }

    public bool? CanSkipVerification { get; set; }

    public bool? IsAgent { get; set; }

    public virtual ServicePackage? Package { get; set; }

    public virtual User? User { get; set; }
}
