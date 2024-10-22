using AutoMapper;
using Repository.DTOs.Auth;
using Repository.DTOs.Order;
using Repository.DTOs.OrderItem;
using Repository.DTOs.Ticket;
using Repository.DTOs.User;
using Repository.DTOs.Wallet;
using Repository.Models;
using Repository.Models.DTOs.Category;
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

            CreateMap<RegisterDTO, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            CreateMap<Ticket, TicketReadDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.CategoryName : string.Empty));

            CreateMap<User, AuthResponseDTO>();
            // Category Mappings
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();
            //User Mappings
            CreateMap<LoginDTORequest, User>().ReverseMap();
            // Ánh xạ giữa OrderItem và OrderItemResponseDTO
            CreateMap<OrderItem, OrderItemResponseDTO>().ReverseMap();
        }
       
    }
}
