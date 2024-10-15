using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepositoy
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
}
