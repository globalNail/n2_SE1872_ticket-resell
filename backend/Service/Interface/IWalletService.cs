using Repository.DTOs.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceWallet
{
    public interface IWalletService
    {
        Task<WalletDTOResponse> GetBalanceByUserId(int userId);
    }
}
