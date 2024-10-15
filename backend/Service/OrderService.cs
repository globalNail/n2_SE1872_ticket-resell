using AutoMapper;
using Repository.DTOs.Order;
using Repository.DTOs.OrderItem;
using Repository.Interfaces;
using Repository.Models;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService :IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IOrderIItemService _itemService;
        public OrderService(IOrderRepository orderRepository, IMapper mapper,IOrderIItemService itemService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _itemService = itemService;
        }
        public async Task<OrderResponseDTO> CreateOrder(CreateOrderDTO dto)
        {
            try
            {
                Order order = new Order();
                //order.OrderId = _orderRepository.GetMaxId()+1;
                order.BuyerId = dto.BuyerId;
                order.CreatedAt = DateTime.UtcNow;
                order.Status = dto.Status;
                if(dto.OrderItems!= null || dto.OrderItems.Count < 1)
                {
                    foreach(var item in dto.OrderItems.ToList())
                    {
                        var newItem = await _itemService.CreateItem(item);
                        order.OrderItems.Add(newItem);
                        order.TotalAmount += newItem.TotalPrice;
                    }
                }
                var result = _mapper.Map<OrderResponseDTO>(order);
                _orderRepository.Insert(order);
                _orderRepository.Save();
                return result;
                
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
