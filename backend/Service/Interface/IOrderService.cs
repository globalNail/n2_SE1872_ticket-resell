using Repository.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IOrderService
    {
        Task<OrderResponseDTO> CreateOrder(CreateOrderDTO dto);
        Task<string?> GetLatestOrderStatusByMember(int buyerId);
    }
}
