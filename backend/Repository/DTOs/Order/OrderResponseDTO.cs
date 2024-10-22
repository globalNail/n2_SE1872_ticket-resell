using Repository.DTOs.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs.Order
{
    public class OrderResponseDTO
    {
        public int OrderId { get; set; }

        public int? BuyerId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? Status { get; set; }

        public decimal? TotalAmount { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public virtual ICollection<OrderItemResponseDTO> OrderItems { get; set; } = new List<OrderItemResponseDTO>();
    }
}
