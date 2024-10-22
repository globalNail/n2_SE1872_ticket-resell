using Repository.DTOs.OrderItem;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs.Order
{
    public class CreateOrderDTO
    {
        public int? BuyerId { get; set; }


        public string? Status { get; set; }

        public virtual ICollection<CreateItemDTO> OrderItems { get; set; } = new List<CreateItemDTO>();
    }
}
