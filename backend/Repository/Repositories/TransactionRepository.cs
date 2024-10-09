using Repository.Base;
using Repository.Models;

namespace Repository.Repositories;

public class TransactionRepository : GenericRepository<Transaction>
{
    private readonly Swp391ticketResellPlatformContext _context;
    public TransactionRepository(Swp391ticketResellPlatformContext context) : base(context)
    {
        _context = context;
    }

}
