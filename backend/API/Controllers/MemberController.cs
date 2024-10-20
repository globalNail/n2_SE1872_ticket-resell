using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.DTOs.Member;
using Service.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberServices _services;

        public MemberController(IMemberServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMember()
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var result = await _services.GetAllMember();
                    if (result == null)
                    {
                        return StatusCode(500, "Failed to getAll the member");
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
        public async Task<IActionResult> GetMemberById(int id)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    var result = await _services.GetMember(id);
                    if (result == null)
                    {
                        return StatusCode(500, "Failed to get the member");
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

        [HttpDelete]
        public async Task<IActionResult> DeleteMember(int id)
        {
            if (ModelState.IsValid)
            {
                await _services.DeleteMember(id);
                return Ok("Delete Successfully");
            }
            return BadRequest(ModelState);

        }

        [HttpPost]
        public async Task<IActionResult> AddMember(MemberDtos memberDtos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _services.AddMember(memberDtos);
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
        public async Task<IActionResult> UpdateMembet(int id, MemberRequest memberRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _services.UpdateMember(id, memberRequest);
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
    }

}
