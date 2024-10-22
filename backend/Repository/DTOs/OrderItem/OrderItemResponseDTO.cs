using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs.OrderItem
{
    public class OrderItemResponseDTO
    {
        public int OrderItemId { get; set; }

        public int? OrderId { get; set; }

        public int? TicketId { get; set; }

        public int? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TotalPrice { get; set; }

        public DateTime? AddedAt { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
