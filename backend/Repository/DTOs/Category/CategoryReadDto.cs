using Repository.DTOs.Ticket;

namespace Repository.Models.DTOs.Category;

public class CategoryReadDto
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    public DateTime? ModifiedDate { get; set; }
    public ICollection<TicketDtos> Tickets { get; set; } = new List<TicketDtos>();
}

