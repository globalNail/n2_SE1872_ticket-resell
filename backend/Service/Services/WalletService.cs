using AutoMapper;
using Repository;
using Repository.DTOs;
using Repository.DTOs.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceWallet
{
    public class WalletService: IWalletService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public WalletService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<WalletDTOResponse> GetBalanceByUserId(int userId)
        {
            try
            {
                var wallet = await _unitOfWork.WalletRepository.GetWalletbyUserId(userId);
                if (wallet == null)
                {
                    throw new Exception("Not Found Wallet!");
                }
                var result = _mapper.Map<WalletDTOResponse>(wallet);
                return result;

            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
