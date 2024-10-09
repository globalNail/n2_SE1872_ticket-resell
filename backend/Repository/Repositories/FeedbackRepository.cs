using Repository.Base;
using Repository.Models;

namespace Repository.Repositories;

public class FeedbackRepository : GenericRepository<Feedback>
{
    private readonly Swp391ticketResellPlatformContext _context;
    public FeedbackRepository(Swp391ticketResellPlatformContext context) : base(context)
    {
        _context = context;
    }
}
