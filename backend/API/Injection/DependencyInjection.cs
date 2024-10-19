using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Base;
using Repository.Interfaces;
using Repository.Models;
using Repository.Repositories;
using Service.Interface;
using Service;
using Service.Mapper;
using Service.ServiceWallet;
using Service.Services;

namespace API.Injection
{
    public static class DependencyInjection
    {
        public static IServiceCollection ServicesInjection(this IServiceCollection services, IConfiguration configuration)
        {
            //CONNECT TO DATABASE
            services.AddDbContext<Swp391ticketResellPlatformContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            //REPOSITORY
            
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<ICategoryyRepository, CategoryRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();

            //GENERIC REPOSITORY
            services.AddScoped<IGenericRepository<Wallet>,GenericRepository<Wallet>>();

            //SERVICE
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<ITicketService, TicketServices>();
            services.AddScoped<IOrderIItemService, OrderItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IMemberServices, MemberServices>();

            //UNIT OF WORK
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //OTHER
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(MapperConfigProfile).Assembly);

            return services;
        }
    }
}
