using Repository.DTOs;
using Repository.Interfaces;
using Repository.Models;
using Service.Interface;

namespace Service
{
    public class TicketServices : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketServices(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<string> AddTicket(TicketDtos ticketDtos)
        {
            if (ticketDtos == null)
            {
                return "Data is null";
            }
            
            Ticket ticket = new Ticket()
            {             
                Barcode = ticketDtos.Barcode,
                Price = ticketDtos.Price,
                Quantity = ticketDtos.Quantity,
                SeatNumber = ticketDtos.SeatNumber,
                SellerId = ticketDtos.SellerId,
                CategoryId = ticketDtos.CategoryId,
                PdfFile = ticketDtos.PdfFile,
                Status = "Verify",
                PostedAt = DateTime.Now,
                ApprovedBy = null,
                ApprovalDate = null,
                ProcessingNotes = ticketDtos.ProcessingNotes,
                ModifiedDate = null
            };
            var result = await _ticketRepository.AddTicket(ticket);
            return result ? "Add Successful" : "Add failed";
        }

        public async Task<int> CountTicket()
        {
           return await _ticketRepository.CountTicket();
        }

        public async Task DeleteTicket(int ticketId)
        {
            try
            {
                if (ticketId == null)
                {
                    throw new Exception("please enter ticketId");
                }
                await _ticketRepository.DeleteTicket(ticketId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Ticket>> GetAllTicket()
        {
            return await _ticketRepository.GetAllTickets();
        }

        public async Task<Ticket> GetTicketById(int ticketId)
        {
            try
            {
                if (ticketId == null)
                {
                    throw new Exception("Please enter ticketId");
                }
                return await GetTicketById(ticketId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> UpdateTicket(int ticketId, TicketUpdatedtos ticketUpdatedtos)
        {
            if (ticketId == null || ticketId == 0)
            {
                return "Please enter ticketId";
            }
            if(ticketUpdatedtos == null)
            {
                return "Data is null";
            }
           var existingTicket = await _ticketRepository.GetTicketsById(ticketId);
            if (existingTicket == null)
            {
                return "ticket not found";
            }
            existingTicket.Quantity = ticketUpdatedtos.Quantity;
            existingTicket.Price = ticketUpdatedtos.Price;
            existingTicket.Status = ticketUpdatedtos.Status;
            existingTicket.ApprovedBy = ticketUpdatedtos.ApprovedBy;
            existingTicket.ApprovalDate = DateTime.Now;
            existingTicket.SeatNumber = ticketUpdatedtos.SeatNumber;
            existingTicket.ProcessingNotes = ticketUpdatedtos.ProcessingNotes;
            existingTicket.ModifiedDate = DateTime.Now;
            var result = await _ticketRepository.UpdateTicket(existingTicket);
            return result ? "Update Successfull" : "Update failed";
        }
    }
}
