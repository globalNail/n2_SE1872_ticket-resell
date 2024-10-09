using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.DTOs;
using Repository.Models;
using Service.Interface;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _services;

        public TicketController(ITicketService ticketService)
        {
            _services = ticketService;
        }

        //CRUD
        [HttpPost]
        public async Task<ActionResult<Ticket>> AddTicket(TicketDtos ticketDtos)
        {
            try
            {
                var result = await _services.AddTicket(ticketDtos);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Read

        [HttpGet()]
        public async Task<IActionResult> GetAllTickets()
        {
            try
            {
                var result = await _services.GetAllTicket();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetTicketById([Required] int ticketId)
        {
            try
            {
                var ticket = await _services.GetTicketById(ticketId);
                if (ticket == null)
                {
                    return NotFound();
                }
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // UPDATE
        [HttpPut]
        public async Task<IActionResult> UpdateTicket(int id, TicketUpdatedtos ticketUpdatedtos)
        {
            try
            {

                var result = await _services.UpdateTicket(id, ticketUpdatedtos);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket([Required] int id)
        {
            try
            {
                await _services.DeleteTicket(id);
                return Ok("delete Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // COUNT
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetTicketCount()
        {
            try
            {
                var count = await _services.CountTicket();
                return Ok(count); // Return the count of tickets
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
