using Repository.Base;
using Repository.Models;

namespace Repository.Repositories;

public class CategoryRepository: GenericRepository<Category>
{
    private readonly Swp391ticketResellPlatformContext _context;
    public CategoryRepository(Swp391ticketResellPlatformContext context) : base(context)
    {
        _context = context;
    }
}
