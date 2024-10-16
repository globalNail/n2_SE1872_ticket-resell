using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs.OrderItem
{
    public class AddItemtoOrderDTO
    {
        public int? OrderId { get; set; }

        public int? TicketId { get; set; }

        public int? Quantity { get; set; }
    }
}
