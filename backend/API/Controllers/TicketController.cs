using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly Swp391TicketResellPlatformV3Context _context;

        public TicketController(Swp391TicketResellPlatformV3Context context)
        {
            _context = context;
        }

        //CRUD
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTodoItem(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(Ticket), new { id = ticket.TicketId }, ticket);
        }
        
        //Read
        
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetAllTickets()
        {
            var tickets = await _context.Tickets.ToListAsync();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTodoItem(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }
        
        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, Ticket ticket)
        {
            if (id != ticket.TicketId)
            {
                return BadRequest(); // Return BadRequest if ID doesn't match
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // Return 204 No Content on successful update
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return NoContent(); // Return 204 No Content on successful deletion
        }

        // COUNT
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetTicketCount()
        {
            var count = await _context.Tickets.CountAsync();
            return Ok(count); // Return the count of tickets
        }

        // Helper method to check if a ticket exists
        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.TicketId == id);
        }
    }
}
