using System.ComponentModel.DataAnnotations;

namespace Repository.Models.DTOs.Category;

public class CategoryCreateDto
{
    [Required]
    [MaxLength(100)]
    public string CategoryName { get; set; } = null!;
}
