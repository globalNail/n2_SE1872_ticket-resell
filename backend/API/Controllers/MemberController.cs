using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var result =  await _services.GetAllMember();  
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetMemberById(int id)
        {
            var result = await _services.GetMemberById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

      
    }
}
