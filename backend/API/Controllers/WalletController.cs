using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Common;
using Repository.DTOs.Wallet;
using Service.ServiceWallet;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;
        private readonly IMapper _mapper;
        public WalletController(IWalletService walletService, IMapper mapper)
        {
            _walletService = walletService;
            _mapper = mapper;
        }
        [HttpGet("GetbyUser/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            try
            {
                var wallet = await _walletService.GetBalanceByUserId(userId);


                var walletDTO = _mapper.Map<WalletDTOResponse>(wallet);

                return Ok(ApiResult<WalletDTOResponse>.Succeed(walletDTO, "Get wallet successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllWallet()
        {
            try
            {
                var wallets = await _walletService.GetAllWallet();


                var listWalletDTO = _mapper.Map<List<WalletDTOResponse>>(wallets);

                return Ok(ApiResult<List<WalletDTOResponse>>.Succeed(listWalletDTO, "Get all wallet successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
