using System.ComponentModel.DataAnnotations;

namespace ProjectOne.Models;

public class Student
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength (100)]
    public string Email { get; set; } = string.Empty;
    public int Phone { get; set; }
}
