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
        private Swp391ticketResellPlatformContext context;
        private GenericRepository<Category> categoryRepository;
        private readonly IWalletRepository _walletRepository;
        public UnitOfWork(Swp391ticketResellPlatformContext _context, IWalletRepository walletRepository)
        {
            context = _context;
            _walletRepository = walletRepository;
        }

        public IGenericRepository<Category> CategoryRepository
        {
            get
            {
                return categoryRepository ??= new GenericRepository<Category>(context);
            }
        }
        public IWalletRepository WalletRepository // Return the injected wallet repository
        {
            get
            {
                return _walletRepository;
            }
        }

        public void Save()
        {
            var validationErrors = context.ChangeTracker.Entries<IValidatableObject>()
                .SelectMany(e => e.Entity.Validate(null))
                .Where(e => e != ValidationResult.Success)
                .ToArray();
            if (validationErrors.Any())
            {
                var exceptionMessage = string.Join(Environment.NewLine,
                    validationErrors.Select(error => $"Properties {error.MemberNames} Error: {error.ErrorMessage}"));
                throw new Exception(exceptionMessage);
            }
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
