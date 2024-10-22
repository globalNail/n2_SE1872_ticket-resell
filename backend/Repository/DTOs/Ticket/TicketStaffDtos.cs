using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs.Ticket
{
    public class TicketStaffDtos
    {
        public string? Status { get; set; }

        public int? ApprovedBy { get; set; }

        public DateTime? ApprovalDate { get; set; }
    }
}
