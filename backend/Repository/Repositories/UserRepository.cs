using Repository.Base;
using Repository.Models;

namespace Repository.Repositories;

public class UserRepository : GenericRepository<User>
{
    private readonly Swp391ticketResellPlatformContext _context;
    public UserRepository(Swp391ticketResellPlatformContext context) : base(context)
    {
        _context = context;
    }
}
