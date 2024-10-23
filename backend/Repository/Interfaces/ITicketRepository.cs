using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAllTickets();
        Task<IEnumerable<Ticket>> GetByCategoryIdAsync(int categoryId);
        Task<Ticket?> GetTicketsById(int Id);
        Task<int> CountTicket();
        Task<bool> AddTicket(Ticket ticket);
        Task DeleteTicket(int ticketId);
        Task<bool> UpdateTicket(Ticket ticket);
    }
}
