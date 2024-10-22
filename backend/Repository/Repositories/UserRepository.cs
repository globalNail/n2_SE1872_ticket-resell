﻿using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly Swp391ticketResellPlatformContext _context;
    public UserRepository(Swp391ticketResellPlatformContext context) : base(context)
    {
        _context = context;
    }

     public async Task<User> GetUserById(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(sc => sc.UserId.Equals(id));
    }
    public async Task<User> GetByUsernameOrEmailAsync(string usernameOrEmail)
    {
        return await _dbSet
            .Include(u => u.Role)
            .Include(u => u.Wallet)
            // .ThenInclude(ur => ur.RoleName)
            .FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);
    }

}
