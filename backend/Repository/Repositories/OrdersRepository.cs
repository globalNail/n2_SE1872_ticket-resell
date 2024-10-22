using Microsoft.EntityFrameworkCore;
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
    public async Task<string?> GetLatestOrderStatusByMemberAsync(int buyerId)
    {
        // Lấy đơn hàng mới nhất của member dựa trên BuyerId
        var latestOrder = await _context.Orders
            .Where(o => o.BuyerId == buyerId)
            .OrderByDescending(o => o.CreatedAt) // Sắp xếp theo thời gian tạo mới nhất
            .FirstOrDefaultAsync();

        // Nếu tìm thấy đơn hàng, trả về trạng thái của nó
        return latestOrder?.Status;
    }
}
