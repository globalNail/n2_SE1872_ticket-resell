using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private Swp391ticketResellPlatformContext _context;
        private GenericRepository<Category> _categoryRepository;

        private readonly IWalletRepository _walletRepository;

        public UnitOfWork(
            Swp391ticketResellPlatformContext context,
            IUserRepository userRepository,
            IUserRoleRepository roleRepository,
            IWalletRepository walletRepository,
            ICategoryRepository categoryRepository,
            ITicketRepository ticketRepository
            )
        {
            _context = context;
            _walletRepository = walletRepository;
            UserRepository = userRepository;
            UserRoleRepository = roleRepository;
            CategoryRepository = categoryRepository;
            TicketRepository = ticketRepository;
        }


        public IWalletRepository WalletRepository // Return the injected wallet repository
        {
            get
            {
                return _walletRepository;
            }
        }

        public IUserRepository UserRepository { get; }

        public IUserRoleRepository UserRoleRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public ITicketRepository TicketRepository { get; }

        public void Save()
        {
            var validationErrors = _context.ChangeTracker.Entries<IValidatableObject>()
                .SelectMany(e => e.Entity.Validate(null))
                .Where(e => e != ValidationResult.Success)
                .ToArray();
            if (validationErrors.Any())
            {
                var exceptionMessage = string.Join(Environment.NewLine,
                    validationErrors.Select(error => $"Properties {error.MemberNames} Error: {error.ErrorMessage}"));
                throw new Exception(exceptionMessage);
            }
            _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
