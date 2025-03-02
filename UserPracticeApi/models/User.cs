using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User{

    [Key]
    public int userId { get; set; }
    [Required]
    public string name { get; set; }
   
   [Required]
   [ForeignKey("Role")]
    public int roleId { get; set; }
    public string? photo { get; set; }
    [Required]
    public string telephone { get; set; }

    [Required]
    public string email { get; set; }




}