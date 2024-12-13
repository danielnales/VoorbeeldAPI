using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoorbeeldAPI.Models;

[Table("Clients")]
public class Client
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string Name { get; set; }

    [Required]
    [Phone]
    public required string Phone { get; set; }
        
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }

    public ClientDto Dto => new() { Id = Id, Name = Name, Phone = Phone };
}
