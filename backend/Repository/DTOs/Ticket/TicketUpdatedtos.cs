﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs.Ticket
{
    public class TicketUpdatedtos
    {
        public int? Quantity { get; set; }
        public decimal Price { get; set; }
        public string? SeatNumber { get; set; }
        public string? Description { get; set; }
    }
}
