using System.ComponentModel.DataAnnotations;

namespace ProjectOne.Models;

public class Teacher
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required, MaxLength(100)]
    public string Email { get; set; }
    public int Phone { get; set; }
    public string Address { get; set; }
}
