using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

[Index(nameof(typeRole), IsUnique = true)] // Define un índice único en el campo "nombre"

public class Role{

    [Key]
    public int roleId { get; set; }
    [Required]
    public string typeRole { get; set; }
    
}