using Repository.Base;
using Repository.Interfaces;

namespace Repository.Models;

public class OrderRepository : GenericRepository<Order> , IOrderRepository
{
    private readonly Swp391ticketResellPlatformContext _context;
    public OrderRepository(Swp391ticketResellPlatformContext context) : base(context)
    {
        _context = context;
    }
    public int GetMaxId()
    {
        
            // Lấy ID lớn nhất từ bảng
            var maxId = _context.Orders.Max(x => x.OrderId);
            return maxId;
    }
}
