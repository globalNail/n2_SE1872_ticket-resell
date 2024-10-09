﻿using System;
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

    public int? RoleId { get; set; }

    public int? WalletId { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Business? Business { get; set; }

    public virtual Member? Member { get; set; }

    public virtual UserRole? Role { get; set; }

    public virtual Staff? Staff { get; set; }

    public virtual Wallet? Wallet { get; set; }
}
