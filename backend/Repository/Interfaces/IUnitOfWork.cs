using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IWalletRepository WalletRepository { get; }
        IUserRepository UserRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ITicketRepository TicketRepository { get; }
        void Save();
        Task<int> SaveChangesAsync();
    }
}
