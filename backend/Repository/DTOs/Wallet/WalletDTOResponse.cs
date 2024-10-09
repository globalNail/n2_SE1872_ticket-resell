using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs.Wallet
{
    public class WalletDTOResponse
    {
        public int WalletId { get; set; }

        public int? UserId { get; set; }

        public decimal? Balance { get; set; }
    }
}
