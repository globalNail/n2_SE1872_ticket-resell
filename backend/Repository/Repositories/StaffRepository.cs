using Repository.Base;
using Repository.Models;

namespace Repository.Repositories;

public class StaffRepository : GenericRepository<Staff>
{
    private readonly Swp391ticketResellPlatformContext _context;
    public StaffRepository(Swp391ticketResellPlatformContext context) : base(context)
    {
        _context = context;
    }
}
