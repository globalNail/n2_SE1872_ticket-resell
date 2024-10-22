using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs.Ticket
{
    public class TicketResponse
    {
        public int TicketId { get; set; }

        public string Barcode { get; set; } = null!;

        public decimal Price { get; set; }

        public int? Quantity { get; set; }

        public string? SeatNumber { get; set; }

        public DateTime? StartDate { get; set; }
        public string? SellerName { get; set; }

        public string CategoryName { get; set; }

        public string? PdfFile { get; set; }

        public string? Status { get; set; }

        public DateTime? PostedAt { get; set; }

        public string? ApprovedBy { get; set; }

        public DateTime? ApprovalDate { get; set; }

        public string? Description { get; set; }

        public DateTime? ModifiedDate { get; set; }

    }
}
