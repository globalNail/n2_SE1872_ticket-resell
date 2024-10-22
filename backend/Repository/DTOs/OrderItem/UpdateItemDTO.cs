using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs.OrderItem
{
    public class UpdateItemDTO
    {
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
