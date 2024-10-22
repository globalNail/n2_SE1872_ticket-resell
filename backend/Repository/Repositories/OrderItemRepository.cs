using Repository.Base;
using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class OrderItemRepository :GenericRepository<OrderItem>, IOrderItemRepository
    {
        private readonly Swp391ticketResellPlatformContext _context;
        public OrderItemRepository(Swp391ticketResellPlatformContext context): base(context)
        {
            _context = context;
        }
       
    }
}
