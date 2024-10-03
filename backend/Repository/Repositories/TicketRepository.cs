using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Models;

namespace Repository.Repositories;

public class TicketRepository : GenericRepository<Ticket>
{
    public TicketRepository(Swp391ticketResellPlatformContext context) => _context = context;

    public async Task<List<Ticket>> GetAllTicketsAsync()
    {
        return await _context.Tickets.Include(t => t.TicketId).ToListAsync();
    }

    public async Task<Ticket> GetTicketsByCustomerId(string Id)
    {
        var result = await _context.Tickets.Include(t => t.TicketId).FirstAsync(u => u.TicketId.ToString() == Id);
        return result;
    }
}
