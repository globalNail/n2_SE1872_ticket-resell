using AutoMapper;
using Repository.DTOs.Order;
using Repository.DTOs.OrderItem;
using Repository.DTOs.Wallet;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapper
{
    public class MapperConfigProfile: Profile
    {
        public MapperConfigProfile() 
        {
            CreateMap<WalletDTOResponse, Wallet>().ReverseMap();
            CreateMap<Order, OrderResponseDTO>()
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems)) // Map OrderItems
            .ReverseMap();

            // Ánh xạ giữa OrderItem và OrderItemResponseDTO
            CreateMap<OrderItem, OrderItemResponseDTO>().ReverseMap();
        }
       
    }
}
