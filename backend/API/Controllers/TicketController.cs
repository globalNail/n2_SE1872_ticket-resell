using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.DTOs.Ticket;
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
        private readonly IMapper _mapper;
        public TicketController(ITicketService ticketService, IMapper mapper)
        {
            _services = ticketService;
            _mapper = mapper;
        }

        //ADD
        [HttpPost]
        public async Task<IActionResult> AddTicket(TicketDtos ticketDtos)

        /// <summary>
        /// Lấy danh sách tất cả các ticket hoặc lọc theo categoryId
        /// GET: api/Tickets?categoryId=1
        /// </summary>
        /// <param name="categoryId">ID của category để lọc</param>
        /// <returns>Danh sách tickets</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketReadDto>>> GetTickets([FromQuery] int? categoryId)

        {
            IEnumerable<Ticket> tickets;

            if (categoryId.HasValue)
            {
                tickets = await _services.GetTicketsByCategoryAsync(categoryId.Value);
            }
            else
            {
                tickets = await _services.GetAllTicketsAsync();
            }

            var ticketsReadDto = _mapper.Map<IEnumerable<TicketReadDto>>(tickets);
            return Ok(ticketsReadDto);
        }
        //CRUD

        #region Add
        [HttpPost]
        public async Task<IActionResult> AddTicket([FromBody]TicketDtos ticketDtos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _services.AddTicket(ticketDtos);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
            return BadRequest(ModelState);

        }
  #endregion
        //Read
  //
  //       #region GetAllTickets
  //       [HttpGet()]
  //       public async Task<IActionResult> GetAllTickets()
  //       {
  //           if (ModelState.IsValid)
  //           {
  //               try
  //               {
  //                   var result = await _services.GetAllTicket();
  //                   if (result == null)
  //                   {
  //                       return NotFound();
  //                   }
  //                   return Ok(result);
  //               }
  //               catch (Exception ex)
  //               {
  //                   return StatusCode(500, $"An error occurred: {ex.Message}");
  //               }
  //           }
  //           return BadRequest(ModelState);
  //
  //       }
  // #endregion

        [HttpGet("Staff")]
        public async Task<IActionResult> GetAllTicketsForStaff()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _services.GetAllTicketForStaff();
                    if (result == null)
                    {
                        return NotFound();
                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
            return BadRequest(ModelState);

        }

        [HttpGet("id")]
        public async Task<IActionResult> GetTicketById([Required] int ticketId)
        {
            if (ModelState.IsValid)
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
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
            return BadRequest(ModelState);

        }

        // UPDATE
        [HttpPut]
        public async Task<IActionResult> UpdateTicket([Required] int id, [FromBody] TicketUpdatedtos ticketUpdatedtos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _services.UpdateTicket(id, ticketUpdatedtos);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
            return BadRequest(ModelState);

        }

        [HttpPut("Staff")]
        public async Task<IActionResult> UpdateTicketByStaff(int staffId, [Required] int id, [FromBody] TicketStaffDtos ticketUpdatedtos)
        {
            if (ModelState.IsValid)
            {
                try
                {               
                    var result = await _services.UpdateTicketForStaff(staffId, id, ticketUpdatedtos);

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
            return BadRequest(ModelState);
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
