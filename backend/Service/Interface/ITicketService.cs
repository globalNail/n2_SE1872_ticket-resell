﻿using Repository.DTOs.Ticket;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ITicketService
    {
        Task<List<TicketResponse>> GetAllTicket();
        Task<List<Ticket>> GetAllTicketsAsync();
        Task<IEnumerable<Ticket>> GetTicketsByCategoryAsync(int categoryId);
        Task<List<TicketResponse>> GetAllTicketForStaff();
        Task<TicketResponse> GetTicketById(int ticketId);
        Task<int> CountTicket();
        Task<string> AddTicket(TicketDtos ticketDtos);
        Task DeleteTicket(int ticketId);
        Task<string> UpdateTicket(int ticketId, TicketUpdatedtos ticketUpdatedtos);
        Task<string> UpdateTicketForStaff(int staffId, int ticketId, TicketStaffDtos ticketUpdatedtos);
    }
}
