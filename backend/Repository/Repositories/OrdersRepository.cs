using Repository.Base;

namespace Repository.Models;

public class OrderRepository : GenericRepository<OrderItem>
{
    private readonly Swp391ticketResellPlatformContext _context;
    public OrderRepository(Swp391ticketResellPlatformContext context) : base(context)
    {
        _context = context;
    }
}
