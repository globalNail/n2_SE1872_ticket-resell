using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly Swp391ticketResellPlatformContext _context;

    public TicketRepository(Swp391ticketResellPlatformContext context)
    {
        _context = context;
    }

    public async Task<List<Ticket>> GetAllTickets()
    {
        return await _context.Tickets.ToListAsync();
    }

    public async Task<int> CountTicket()
    {
        return await _context.Tickets.CountAsync();
    }

    public async Task<Ticket> GetTicketsById(int Id)
    {
        return await _context.Tickets.FirstOrDefaultAsync(sc => sc.TicketId.Equals(Id));
    }

    public async Task<bool> AddTicket(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task DeleteTicket(int ticketId)
    {
        var ticket = await GetTicketsById(ticketId);
        if (ticket != null)
        {
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> UpdateTicket(Ticket ticket)
    {
        _context.Tickets.Update(ticket);
       return await _context.SaveChangesAsync() > 0;
    }
}
