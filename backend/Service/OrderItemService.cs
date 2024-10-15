using AutoMapper;
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
    public class OrderItemService : IOrderIItemService
    {
        private readonly IOrderItemRepository _itemRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        public OrderItemService(IOrderItemRepository itemRepository, ITicketRepository ticketRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }
        public async Task<OrderItem> CreateItem(CreateItemDTO dto)
        {
            try
            {
                if(dto == null) 
                {
                    throw new Exception("DTO is empty");
                }
                var ticket = await _ticketRepository.GetTicketsById((int)dto.TicketId);
                OrderItem item = new OrderItem();
                
                item.TicketId = dto.TicketId;
                item.Quantity = dto.Quantity;
                item.UnitPrice = ticket.Price;
                item.TotalPrice = item.UnitPrice * item.Quantity;
                item.AddedAt = DateTime.UtcNow;
                _itemRepository.Insert(item);
                return item;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task <OrderItemResponseDTO> UpdateItem(UpdateItemDTO dto, int id)
        {
            try
            {
                if(dto == null)
                {
                    throw new Exception("DTO ist empty");
                }
                var existingItem = _itemRepository.GetByID(id);
                existingItem.Quantity = dto.Quantity;
                existingItem.TotalPrice = existingItem.UnitPrice * dto.Quantity;
                existingItem.ModifiedDate = DateTime.UtcNow;
                var result = _mapper.Map<OrderItemResponseDTO>(existingItem);
                _itemRepository.Update(existingItem);
                _itemRepository.Save();
                return result;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
