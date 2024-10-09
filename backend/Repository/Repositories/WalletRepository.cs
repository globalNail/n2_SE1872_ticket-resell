using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Repositories;

public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
{
    private readonly Swp391ticketResellPlatformContext _context;
    public WalletRepository(Swp391ticketResellPlatformContext context) : base(context)
    {
        _context = context;
    }
    public async Task<Wallet> GetWalletbyUserId(int userId)
    {
        return await _context.Wallets.FirstOrDefaultAsync(x => x.UserId == userId);
    }
}
