using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class ServicePackage
{
    public int PackageId { get; set; }

    public string PackageName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Fee { get; set; }

    public decimal? DiscountPercentage { get; set; }

    public virtual ICollection<Business> Businesses { get; set; } = new List<Business>();
}
