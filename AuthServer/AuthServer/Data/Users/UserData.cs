using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.Data;

[PrimaryKey("Id")]
public class UserData
{
    public required int Id { get; set; }
    [ForeignKey("ApplicationUser")]
    public required ApplicationUser User { get; set; }
    
    [MaxLength(5000)]
    public string? Description { get; set; }
    
    [MaxLength(50)]
    public string? Nickname { get; set; }
    
    // stat lines
    // JSON string of all kinds of stats
    public string? UserJSON { get; set; }
}