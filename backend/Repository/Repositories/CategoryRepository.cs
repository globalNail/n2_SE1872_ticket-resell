using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Repositories;

public class CategoryRepository: GenericRepository<Category>, ICategoryyRepository
{
    private readonly Swp391ticketResellPlatformContext _context;
    public CategoryRepository(Swp391ticketResellPlatformContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Category> GetCategoryById(int? id)
    {
        return await _context.Categories.FirstOrDefaultAsync(sc => sc.CategoryId.Equals(id));
    } 
}
