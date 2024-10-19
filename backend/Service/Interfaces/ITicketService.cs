using Repository.DTOs;
using Repository.Models;

namespace Service.Interface
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetAllTicket();
        Task<Ticket> GetTicketById(int ticketId);
        Task<int> CountTicket();
        Task<string> AddTicket(TicketDtos ticketDtos);
        Task DeleteTicket(int ticketId);
        Task<string> UpdateTicket(int ticketId, TicketUpdatedtos ticketUpdatedtos);
    }
}