using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Repositories;

public class StaffRepository : GenericRepository<Staff>, IStaffRepository
{
    private readonly Swp391ticketResellPlatformContext _context;
    public StaffRepository(Swp391ticketResellPlatformContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Staff>> GetAllStaff()
    {
        return await _context.Staff.ToListAsync();
    }

    public async Task<Staff> GetStaffById(int? id)
    {
        return await _context.Staff.Include(s => s.User).FirstOrDefaultAsync(sc => sc.StaffId.Equals(id));
    }

    public async Task<bool> AddStaff(Staff staff)
    {
        _context.Staff.Add(staff);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateStaff(Staff staff)
    {
        _context.Staff.Update(staff);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task DeleteStaffById(int? id)
    {
        var staff = await GetStaffById(id);
        if (staff != null)
        {
            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync(); 
        }
    }


}
