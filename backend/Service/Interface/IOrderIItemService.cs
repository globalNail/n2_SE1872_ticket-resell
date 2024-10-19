using Repository.DTOs.OrderItem;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IOrderIItemService
    {
        Task<OrderItem> CreateItem(CreateItemDTO dto);
    }
}
