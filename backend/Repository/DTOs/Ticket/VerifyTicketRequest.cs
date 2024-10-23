using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs.Ticket
{
    public class VerifyTicketRequest
    {
        public int CategoryId { get; set; }
        public string Barcode { get; set; } 
    }
}
