namespace Repository.DTOs.Ticket;

public class TicketReadDto
{
    public int TicketId { get; set; }
    public string Barcode { get; set; } = null!;
    public decimal Price { get; set; }
    public int? Quantity { get; set; }
    public string? SeatNumber { get; set; }
    public DateTime? StartDate { get; set; }
    public string? Status { get; set; }
    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
}
