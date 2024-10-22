using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.DTOs.Staff;
using Service.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffServices _services;

        public StaffController(IStaffServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStaff()
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var result = await _services.GetAllStaff();
                    if (result == null)
                    {
                        return StatusCode(500, "Failed to getAll the staff");
                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
            return BadRequest(ModelState); // Return a 400 response with validation errors
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetStaffById(int? id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(id == null)
                    {
                        return BadRequest("Please enter staff's id");
                    }
                    var result = await _services.GetStaffById(id);
                    if (result == null)
                    {
                        return StatusCode(500, "Failed to getAll the staff");
                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
            return BadRequest(ModelState); // Return a 400 response with validation errors
        }

        [HttpPost]
        public async Task<IActionResult> AddStaff(StaffDtos staffDtos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _services.AddStaff(staffDtos);
                    if (result == null)
                    {
                        return StatusCode(500, "Failed to add the member");
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

        [HttpPut]
        public async Task<IActionResult> UpdateStaff(int? id, StaffDtos staffDtos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(id == null)
                    {
                        return BadRequest("Please enter the Staff's id");
                    }
                    var result = await _services.UpdateStaff(id, staffDtos);
                    if (result == null)
                    {
                        return StatusCode(500, "Failed to update the member");
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

        [HttpDelete]
        public async Task<IActionResult> DeleteStaff(int? id)
        {
            if (ModelState.IsValid)
            {
                if(id == null || id == 0)
                {
                    return BadRequest("Please enter the Staff's id");
                }
                await _services.DeleteStaffById(id);
                return Ok("Delete Successfully");
            }
            return BadRequest(ModelState);
        }
    }
}
