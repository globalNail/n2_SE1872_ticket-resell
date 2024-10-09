using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Base;
using Repository.Interfaces;
using Repository.Models;
using Repository.Repositories;
using Service.Mapper;
using Service.ServiceWallet;

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
            services.AddScoped<IWalletRepository, WalletRepository>();

            //GENERIC REPOSITORY
            services.AddScoped<IGenericRepository<Wallet>,GenericRepository<Wallet>>();

            //SERVICE
            services.AddScoped<IWalletService, WalletService>();

            //UNIT OF WORK
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //OTHER
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(MapperConfigProfile).Assembly);

            return services;
        }
    }
}
